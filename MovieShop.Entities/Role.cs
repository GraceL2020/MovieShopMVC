using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{
    [Table("Role")]
    public class Role
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
