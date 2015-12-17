using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCDocumentDBDemo.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Threading.Tasks;

namespace POCDocumentDBDemo.Data
{
    public interface IRepository <TEntity> where TEntity:Entity
    {
        Task<ResourceResponse<Document>> Add (TEntity entity);
        Task<TEntity> get (Guid id);
        Task<ResourceResponse<Document>> Update (TEntity entity);
        Task<ResourceResponse<Document>> Delete (Guid id);
        
        Task<List<TEntity>> get ();
       // IQueryable<TEntity> Items { get; }

    }
}