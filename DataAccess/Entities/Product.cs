using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataAccess.Entities
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Please Insert Product Name")]
        public string Name { get; set; }
        public string  ExpierName { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
