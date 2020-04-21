using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{
    [Table("Favorite")]
    public class Favorite
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int UserId { get; set; }

        public Movie Movie { get; set; }

        public User User { get; set; }

    }
}
