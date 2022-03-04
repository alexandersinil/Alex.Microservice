using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NHibernate;

namespace Alex.Persistance.NHibernate
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        public ISession Session { get; }

        public NHibernateUnitOfWork(ISession session)
        {
            this.Session = session;
        }

        public void Flush()
        {
            this.Session.Flush();
        }
        public void Insert<TEntity, TIdentity>(TEntity entity) where TEntity : class
        {
            this.Session.Save((object)entity);
            this.Session.Flush();
        }
        public void Update<TEntity, TIdentity>(TEntity entity) where TEntity : class
        {
            this.Session.Update((object)entity);
            this.Session.Flush();
        }
        public void Delete<TEntity, TIdentity>(TEntity entity) where TEntity : class
        {
            this.Session.Delete((object)entity);
            this.Session.Flush();
        }
        public TEntity GetById<TEntity, TIdentity>(long id) where TEntity : class
        {
            return this.Session.Get<TEntity>(id);
        }

        public IList<TEntity> GetAll<TEntity, TIdentity>() where TEntity : class
        {
            return this.Session.CreateCriteria<TEntity>().SetCacheable(false).List<TEntity>();
        }

        public IQueryable<TEntity> ToQueryable<TEntity, TIdentity>() where TEntity : class
        {
            return this.Session.Query<TEntity>();
        }

        public IEnumerable<TElement> ExecuteFunction<TElement>(
          string functionName,
          MethodInfo methodInfo,
          params object[] parameters)
        {
            IQuery namedQuery = this.Session.GetNamedQuery(functionName);
            ParameterInfo[] parameters1 = methodInfo.GetParameters();
            for (int index = 0; index < parameters.Length; ++index)
            {
                string name = parameters1[index].Name;
                object parameter = parameters[index];
                namedQuery.SetParameter(name, parameter);
            }
            return (IEnumerable<TElement>)namedQuery.List<TElement>();
        }

        public IEnumerable<TElement> ExecuteFunction<TElement>(
          string functionName,
          params Tuple<string, object>[] parameters)
        {
            IQuery namedQuery = this.Session.GetNamedQuery(functionName);
            for (int index = 0; index < parameters.Length; ++index)
            {
                string name = parameters[index].Item1;
                object val = parameters[index].Item2;
                namedQuery.SetParameter(name, val);
            }
            return (IEnumerable<TElement>)namedQuery.List<TElement>();
        }

        public void Dispose()
        {
            this.Session?.Dispose();
        }

        public void GetById<TEntity, TIdentity>(TEntity id) where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}