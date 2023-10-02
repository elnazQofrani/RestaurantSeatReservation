using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Basket
    {
        [Key]
        public int Id { get; set; }
   
        public  int CustomerId { get; set; }
       
        public  int ProductId { get; set; }

        public int ProductNum { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get;set; }


    }
}
