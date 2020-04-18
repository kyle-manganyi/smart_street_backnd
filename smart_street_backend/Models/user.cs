using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smart_street_backend.Model
{
    public class user
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email {get; set;}
        public string password {get; set;}
        public string phone {get; set;}
        public string location {get; set;}
        public string name {get; set;}
        
    }
}
