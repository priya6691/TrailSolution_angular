using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POCDocumentDBDemo.Models
{
    public class Products :Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}