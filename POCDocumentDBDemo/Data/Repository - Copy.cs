//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using POCDocumentDBDemo.Models;
//using System.Collections.Concurrent;

//namespace POCDocumentDBDemo.Data
//{
//    public class RepositoryCopy<TEntity> :IRepository<TEntity>  where TEntity:Entity
//    {
//        public ConcurrentDictionary<Guid,TEntity> _concurrentDictionarycopy = new ConcurrentDictionary<Guid,TEntity>();
                         
//        #region IRepository<TEntity> Members

//        public TEntity Add (TEntity entity)
//        {
//            //throw new NotImplementedException ( );
//            bool result = _concurrentDictionarycopy.TryAdd ( entity.Id, entity );
//            if (!result) { return null;};
//            return entity;
//        }

//        public TEntity get (Guid id)
//        {
//           TEntity entity;
//           bool result = _concurrentDictionarycopy.TryGetValue ( id, out entity );
//           if (!result) { return null;};
//           return entity;
//        }

//        public TEntity Update (TEntity entity)
//        {
//            if (!_concurrentDictionarycopy.ContainsKey( entity.Id))
//            {
//                return null; 
//            }
//            _concurrentDictionarycopy[entity.Id] = entity;
//            return entity;
//        }

//        public TEntity Delete (Guid id)
//        {
//            TEntity entity;
//            bool Result = _concurrentDictionarycopy.TryRemove (id,out entity );
//            if (!Result) { return null; };
//            return entity;
//        }

//        public IQueryable<TEntity> Items
//        {
//            get { return _concurrentDictionarycopy.Values.AsQueryable ( ); }
//        }

//        #endregion
//    }
//}