using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace smart_street_backend.Model
{
    public class cart
    {
        public int Id { get; set; }
        public string location {get;set;}
        public DateTime openDate {get; set;}


        [ForeignKey("order")]
        public int orderID { get; set; }
        public virtual order ordr { get; set; }
    }
}
