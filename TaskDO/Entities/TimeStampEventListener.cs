using System;
using System.Security.Principal;
using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace TaskDO.Entities
{
    public class TimeStampEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        #region IPreInsertEventListener Members

        public bool OnPreInsert(PreInsertEvent @event)
        {
            var entity = @event.Entity as Entity;
            if (entity == null)
                return false;


            DateTime time = DateTime.Now;
            string name = WindowsIdentity.GetCurrent().Name;

            Set(@event.Persister, @event.State, "CreatedAt", time);
            Set(@event.Persister, @event.State, "UpdatedAt", time);
            Set(@event.Persister, @event.State, "CreatedBy", name);
            Set(@event.Persister, @event.State, "UpdatedBy", name);

            entity.CreatedAt = time;
            entity.CreatedBy = name;
            entity.UpdatedAt = time;
            entity.UpdatedBy = name;

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
            string name = WindowsIdentity.GetCurrent().Name;

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
    }
}