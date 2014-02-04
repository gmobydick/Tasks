using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate;
using TaskDO.DAO;
using TaskDO.Entities;
using TaskMVC.Areas.Admin.Models;
using log4net;

namespace TaskMVC.Areas.Admin.Controllers
{
    public class ProjectController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProjectController));
        private readonly ISession _session = MvcApplication.SessionFactory.GetCurrentSession();
        private readonly ProjectDAO _projectDAO = new ProjectDAO();
        public ProjectModel Model = new ProjectModel();

        public ProjectController()
        {
            Model.AllProjects = _projectDAO.GetAll(_session);
        }

        //
        // GET: /Admin/Project/

        public ActionResult Index()
        {
            return View(Model);
        }

        //
        // GET: /Admin/Project/Details/5

        public ActionResult Details(int id)
        {

            return View(Model.SelectedProject);
        }

        //
        // GET: /Admin/Project/Create

        public ActionResult Create()
        {
            Model.SelectedProject = new Project();
            return View(Model);
        }

        //
        // POST: /Admin/Project/Create

        [HttpPost]
        public ActionResult Create(ProjectModel model)
        {
            try
            {
                _projectDAO.SaveOrUpdate(_session, model.SelectedProject);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message, exception);
                ViewBag.Message = exception.Message;
                return View(model);
            }
        }

        //
        // GET: /Admin/Project/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Project/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Project/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Project/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
