using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public string Family { get; set; }
        [Required(ErrorMessage ="Email is Essencial")]
        public string Email { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }

    }
}
