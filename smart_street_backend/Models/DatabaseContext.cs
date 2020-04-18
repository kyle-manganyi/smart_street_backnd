using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace smart_street_backend.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options): base(options)
        {

        }
        public DatabaseContext() { }

        public DbSet<user> users { get; set; }
        public DbSet<cart> carts {get;set;}
        public DbSet<catergory> catergories {get;set;}
        public DbSet<customer> customers {get;set;}
        public DbSet<image> images {get;set;}
        public DbSet<order> orders {get;set;}
        public DbSet<product> products {get;set;}
        public DbSet<sale> sales {get;set;}
        public DbSet<supplier> suppliers {get;set;}

    }
}
