using System;
using System.Web.Mvc;
using System.Web.Routing;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using TaskDO.Entities;
using log4net;
using log4net.Config;

namespace TaskMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MvcApplication));
        public static ISessionFactory SessionFactory { get; private set; }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new[] {"TaskMVC.Controllers"}
            );

        }

        protected void Application_Start()
        {
            //Configure log4net
            XmlConfigurator.Configure();
            
            //Handle Mobile devices. Detect and redirect to Mobile Area
            GlobalFilters.Filters.Add(new RedirectMobileDevicesToMobileAreaAttribute(), 1);
            
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            SessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(c => c.FromConnectionStringWithKey("cafebabeDB"))
                              //.ConnectionString(c => c.FromConnectionStringWithKey("kurtDB"))
                              //.Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
                              .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Task>())
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                //.ExposeConfiguration(preUp =>
                //{
                //    preUp.EventListeners.PreUpdateEventListeners =
                //        new IPreUpdateEventListener[] { new EntityListener() };
                //})
                //.ExposeConfiguration(preIn =>
                //{
                //    preIn.EventListeners.PreInsertEventListeners =
                //        new IPreInsertEventListener[] { new EntityListener() };
                //})
                //.ExposeConfiguration(postUp =>
                //{
                //    postUp.EventListeners.PostUpdateEventListeners =
                //        new IPostUpdateEventListener[] { new EntityListener() };
                //})
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
            NHibernateProfiler.Initialize();
            Log.Debug("Application started!");
            Log.Info("Application started!");
            Log.Error("Application started!");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            ISession session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(SessionFactory);
            session.Dispose();
        }

        private static void BuildSchema(Configuration config)
        {
            //Tries tu update the datamodel without destroying data
            // 1st parameter - Show DDL (Data Definition Language) in consolet)
            // 2nd parameter - Run DDL mot databasen(Make tables and relations according to mapping, but only update if table already exists).
            new SchemaUpdate(config).Execute(false, true);

            //#region Create from scratch
            //// this NHibernate tool takes a configuration (with mapping info in)
            //// and exports a database schema from it
            //// 1st parameter - Show DDL (Data Definition Language) in consolet)
            //// 2nd parameter - Run DDL mot databasen(Make tables and relations according to mapping).
            //new SchemaExport(config).Create(true, true);
            //#endregion
        }
    }
}