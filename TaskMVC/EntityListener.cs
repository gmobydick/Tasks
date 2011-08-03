using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using NHibernate.Event;
using NHibernate.Persister.Entity;
using TaskDO.Entities;

namespace TaskMVC
{
    public class EntityListener : IPreUpdateEventListener, IPreInsertEventListener
    //, IPostUpdateEventListener//, IPostDeleteEventListener, IPostInsertEventListener
    {
        #region IPreInsertEventListener Members

        public bool OnPreInsert(PreInsertEvent @event)
        {
            var entity = @event.Entity as Entity;
            if (entity == null)
                return false;


            DateTime time = DateTime.Now;
            string name = GetUserId();

            Set(@event.Persister, @event.State, "CreatedAt", time);
            //Set(@event.Persister, @event.State, "UpdatedAt", null);
            Set(@event.Persister, @event.State, "CreatedBy", name);
            //Set(@event.Persister, @event.State, "UpdatedBy", null);

            entity.CreatedAt = time;
            entity.CreatedBy = name;
            //entity.UpdatedAt = null;
            //entity.UpdatedBy = null;

            return false;
        }

        #endregion

        #region IPreUpdateEventListener Members

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            var entity = @event.Entity as Entity;
            if (entity == null)
                return false;

            DateTime time = DateTime.Now;
            string name = GetUserId();

            Set(@event.Persister, @event.State, "UpdatedAt", time);
            Set(@event.Persister, @event.State, "UpdatedBy", name);

            entity.UpdatedAt = time;
            entity.UpdatedBy = name;

            return false;
        }

        #endregion

        private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            int index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }

        private string GetUserId()
        {
            if (HttpContext.Current.User != null)
            {
                // see if this user is authenticated, any authenticated cookie (ticket) exists for this user

                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    // see if the authentication is done using FormsAuthentication
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        var identity = (FormsIdentity)HttpContext.Current.User.Identity;

                        return identity.Name;
                    }
                    // see if the authentication is done using FormsAuthentication
                    if (HttpContext.Current.User.Identity is WindowsIdentity)
                    {
                        var identity = (WindowsIdentity)HttpContext.Current.User.Identity;

                        return identity.Name;
                    }
                }
            }
            return "unauth";
        }

        //public void OnPostUpdate(PostUpdateEvent @event)
        //{
        //    FindDirty(@event.Persister, @event.State, @event.OldState, @event.Entity, @event.Session);
        //}

        //public void OnPostDelete(PostDeleteEvent @event)
        //{
        //    FindDirty(@event.Persister, null, null, @event.Entity, @event.Session);
        //}

        //public void OnPostInsert(PostInsertEvent @event)
        //{
        //    FindDirty(@event.Persister, @event.State, null, @event.Entity, @event.Session);
        //}

        //private void FindDirty(IEntityPersister persister, object[] state, object[] oldState, object entity, IEventSource session)
        //{
        //    int[] dirtyFieldIndexes = persister.FindDirty(state, oldState, entity, session);

        //    foreach (int dirtyFieldIndex in dirtyFieldIndexes)
        //    {
        //        string property = persister.PropertyNames[dirtyFieldIndex];
        //        object oldValue = oldState[dirtyFieldIndex];
        //        object newValue = state[dirtyFieldIndex];

        //        CreateAuditLogForAction(persister, (Entity)entity, AuditAction.PostUpdate, property, oldValue, newValue);
        //    }
        //}

        //private void CreateAuditLogForAction(IEntityPersister persister, Entity entity, AuditAction action, string property, 
        //    object oldValue, object newValue)
        //{
        //    if(entity.GetType() != typeof(AuditLog))
        //    {
        //        ISession session = MvcApplication.SessionFactory.GetCurrentSession();
        //        var auditDAO = new AuditDAO();
        //        AuditLog log = new AuditLog
        //                           {
        //                               EntityType = entity.GetType().ToString(),
        //                               EntityId = entity.Id,
        //                               ActionBy = entity.CreatedBy,
        //                               ActionTimestamp = new DateTime(),//entity.CreatedAt.ToString(),
        //                               Action = action,
        //                               UserIp = "TTTT",
        //                               PropertyName = property,
        //                               OldPropertyValue = oldValue.ToString(),
        //                               NewPropertyValue = newValue.ToString()
        //                           };
        //        auditDAO.SaveOrUpdate(session, log);
        //    }
        //}
    }
}