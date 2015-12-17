using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POCDocumentDBDemo.Models;
using POCDocumentDBDemo.Data;
using System.Threading.Tasks;

namespace POCDocumentDBDemo.Controllers
{
    public class ProductsController : ApiController
    {
        public static IRepository<Products> ProductsRepository;

        public ProductsController () 
        {
          //  Products abc = new Products ( ) { Id = new Guid ( ), Name = "Testcalled from POC", Price = 200 };
            ProductsRepository = new Repository<Products> ( );
           // ProductsRepository.Add ( abc );
        
        }
      
        public async Task<Products> Get (Guid id)
        {
            var entity = await ProductsRepository.get(id);
            if (entity == null) { throw new HttpResponseException ( HttpStatusCode.NotFound );}
            return entity;
        }

        public async Task<List<Products>> Get ()
        {
            var entity = await ProductsRepository.get();
            if (entity == null) { throw new HttpResponseException ( HttpStatusCode.NotFound ); }
            return entity;
        }
        // POST api/<controller>
        public async Task<HttpResponseMessage> Post (Products value)
        {           
            var result =  await ProductsRepository.Add ( value );
            if (result ==null){ throw new HttpResponseException(HttpStatusCode.Conflict);}
            var response = Request.CreateResponse<Products> ( HttpStatusCode.Created, value );
            //string uri = Url.Link()
            return response;
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put (Products value)
        {
           throw new NotImplementedException();
        }

        // DELETE api/<controller>/5
        public async Task<HttpResponseMessage> Delete (Guid id)
        {
            var result = await ProductsRepository.Delete ( id );
            if (result == null) { throw new HttpResponseException ( HttpStatusCode.NotFound ); };
            return Request.CreateResponse(HttpStatusCode.OK,result);
        }
    }
}