
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class CRUDDbConnection : DbContext
    { 
        public CRUDDbConnection(  ) : base("conn")
        {

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
