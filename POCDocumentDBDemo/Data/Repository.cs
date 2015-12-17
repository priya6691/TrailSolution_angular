using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCDocumentDBDemo.Models;
using System.Collections.Concurrent;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Threading.Tasks;

namespace POCDocumentDBDemo.Data
{
    public class Repository<TEntity> : DocumentDb,IRepository<TEntity> where TEntity : Entity 
    {
        public Repository() : base ( "DocumentDB", "Product" ) { }
        
   //     public ConcurrentDictionary<Guid,TEntity> _concurrentDictionary = new ConcurrentDictionary<Guid,TEntity>();
                         
        #region IRepository<TEntity> Members
             

        public Task<ResourceResponse<Document>> Add (TEntity entity)
        {
         return Client.CreateDocumentAsync ( Collection.DocumentsLink, entity );

        }

        public Task<TEntity> get (Guid id)
        {
            return Task<TEntity>.Run ( () => Client.CreateDocumentQuery<TEntity> ( Collection.DocumentsLink ).Where ( p => p.Id == id ).AsEnumerable ( ).FirstOrDefault ( ) );
        }

        public Task<List<TEntity>> get ()
        {
            return Task<List<TEntity>>.Run ( () => Client.CreateDocumentQuery<TEntity> ( Collection.DocumentsLink ).ToList ( ) );
        }

        public Task<ResourceResponse<Document>> Update (TEntity entity)
        {
           var updatedDoc = Client.CreateDocumentQuery<Document> ( Collection.DocumentsLink ).Where ( a => a.Id == entity.Id.ToString() ).AsEnumerable ( ).FirstOrDefault ( );
          return  Client.ReplaceDocumentAsync ( updatedDoc.SelfLink, entity );
        }


        public Task<ResourceResponse<Document>> Delete (Guid id)
        {
            var docDeleted = Client.CreateDocumentQuery<Document> ( Collection.DocumentsLink ).Where ( a => a.Id == id.ToString() ).AsEnumerable ( ).FirstOrDefault ( );
            return Client.DeleteDocumentAsync ( docDeleted.SelfLink );
        }
      

     //   public IQueryable<TEntity> Items
     //   {
      //      get { return _concurrentDictionary.Values.AsQueryable ( ); }
     //   }

        #endregion
    }
}