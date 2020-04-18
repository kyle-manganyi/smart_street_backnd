using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace smart_street_backend.Model
{
    public class product
    {
        public int Id { get; set; }
        public string description {get; set;}
        public string name {get; set;}
        public double price {get; set;}
        public int stockCount {get; set;}

        [ForeignKey("supplier")]
        public int supplierId { get; set; }
        public virtual supplier Supplier { get; set; }

        [ForeignKey("catergory")]
        public int catergoryID { get; set; }
        public virtual catergory Catergory { get; set; }
    }
}
