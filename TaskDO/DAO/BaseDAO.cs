using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using TaskDO.Entities;

namespace TaskDO.DAO
{
    public abstract class BaseDAO<T> where T : Entity
    {
        public T GetById(ISession session, int id)
        {
            //using (ISession session = SessionFactoryManager.Instance.OpenSession())
            //{
            //try
            //{
            var entity = session.Get<T>(id);

            return entity;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //}
        }

        //public T GetByUniqeName(ISession session, string name)
        //{
        //    var entity = session.Get<T>(name);
        //    return entity;
        //}

        public T SaveOrUpdate(ISession session, T entity)
        {
            //using (ISession session = SessionFactoryManager.Instance.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdateCopy(entity);
                    transaction.Commit();

                    return entity;
                }
                catch (Exception)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }

                    throw;
                }
            }
        }

        public T Delete(ISession session, T entity)
        {
            //using (ISession session = SessionFactoryManager.Instance.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Delete(entity);
                    transaction.Commit();

                    return entity;
                }
                catch (Exception)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }

                    throw;
                }
            }
        }

        public IList<T> GetAll(ISession session)
        {
            IList<T> entities = session.QueryOver<T>().List<T>();

            return entities;
        }

        public IList<T> GetByName(ISession session, string name)
        {
            IList<T> entities = session.QueryOver<T>().
                WhereRestrictionOn(x => x.Name).
                IsInsensitiveLike(name, MatchMode.Anywhere).
                List<T>();

            return entities;
        }
    }
}