using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POCDocumentDBDemo.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}