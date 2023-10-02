using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class EfCustomer : ICustomer
    {
 

        private CRUDDbConnection db;

        public EfCustomer(CRUDDbConnection _db)
        {
            db = _db;
        }
        public Entities.Customer GetCustomerById(int id)
        {
            return db.Customer.Find(id);
        }

        public Boolean AddCustomer(Entities.Customer model)
        {
            db.Customer.Add(model);
            db.SaveChanges();
            return true;
        }

        public Boolean RemoveCustomer(Entities.Customer model)
        {
            db.Customer.Remove(model);
            db.SaveChanges();
            return true;
        }

        public Boolean CustomerEdit(Entities.Customer model)
        {
            Entities.Customer customer = new Entities.Customer();
            customer.Name = model.Name;
            customer.Email = model.Email;
            customer.Family = model.Family;

            db.SaveChanges();
            return true;
        }

        public List<Entities.Customer> CustmoerList()
        {
            return db.Customer.ToList();
        }

    }
}
