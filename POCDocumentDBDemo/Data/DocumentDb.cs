using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Configuration;
using System.Threading.Tasks;

namespace POCDocumentDBDemo.Data
{
    public class DocumentDb
    {
        private static string _databaseId,_CollectionId;
        private static DocumentClient _client;
        private static Database _database;
        private static DocumentCollection _documentCollection;

        public DocumentDb(string database,string collection)
        {
            _databaseId=database;
            _CollectionId=collection;
            ReadorCreateDatabase().Wait();
            ReadorCreatDocumentCollection( _database.SelfLink).Wait();
         
        }
        
        public static DocumentClient Client
        {
            get
            {
                if(_client ==null)
                {
                    string documentendpoint = ConfigurationManager.AppSettings["DocumentDbendpoint"];
                    string authKey = ConfigurationManager.AppSettings["authKey"];
                    Uri endpoint = new Uri(documentendpoint);
                    _client = new DocumentClient(endpoint,authKey);
                }
                return _client;
            }
        }

        protected static DocumentCollection Collection { get { return _documentCollection; } }

        public static async Task ReadorCreateDatabase()
        {
            var query = Client.CreateDatabaseQuery ( ).Where ( db => db.Id == _databaseId );
            var a = query.ToArray ( );
            if (a.Any ( ))
            {
                _database = a.First ( );
            }
            else 
            {
                _database = await Client.CreateDatabaseAsync ( new Database { Id = _databaseId } );
            }                      
        }

        public static async Task ReadorCreatDocumentCollection (string Database) 
        {
            var Collections = Client.CreateDocumentCollectionQuery ( Database ).Where ( col => col.Id == _CollectionId ).ToArray ( );
            if (Collections.Any ( ))
            {
                _documentCollection = Collections.First ( );
            }

            else 
            {
                _documentCollection = await Client.CreateDocumentCollectionAsync ( Database, new DocumentCollection { Id=_CollectionId} );
            }
        }



    }
}