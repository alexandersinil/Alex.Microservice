using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Alex.Persistance.NHibernate
{
    public interface IUnitOfWork : IDisposable
    {
        void Flush();
        void Insert<TEntity, TIdentity>(TEntity entity) where TEntity : class;
        void Update<TEntity, TIdentity>(TEntity entity) where TEntity : class;
        TEntity GetById<TEntity, TIdentity>(long id) where TEntity : class;
        IList<TEntity> GetAll<TEntity, TIdentity>() where TEntity : class;
        IQueryable<TEntity> ToQueryable<TEntity, TIdentity>() where TEntity : class;
        IEnumerable<TElement> ExecuteFunction<TElement>(string functioName, MethodInfo methodInfo, params object[] parameters);
        IEnumerable<TElement> ExecuteFunction<TElement>(string functionName, params Tuple<string, object>[] parameters);
    }
}