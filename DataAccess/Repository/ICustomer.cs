using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICustomer

    {
        Entities.Customer GetCustomerById(int id);
        Boolean AddCustomer(Entities.Customer model);
        Boolean RemoveCustomer(Entities.Customer model);
        Boolean CustomerEdit(Entities.Customer model);
        List<Entities.Customer> CustmoerList();


    }
}
