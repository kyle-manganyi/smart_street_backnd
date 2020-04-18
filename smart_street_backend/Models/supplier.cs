using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace smart_street_backend.Model
{
    public class supplier
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual user user { get; set; }
    }
}
