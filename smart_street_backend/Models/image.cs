using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace smart_street_backend.Model
{
    public class image
    {
        public int Id { get; set; }
        public string imageUrl {get; set;}

        [ForeignKey("product")]
        public int productID { get; set; }
        public virtual product product { get; set; }
    }
}
