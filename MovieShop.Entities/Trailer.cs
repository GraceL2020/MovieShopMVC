using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{
    [Table("Trailer")]
    public class Trailer
    {
        public int Id { get; set; }

        [StringLength(2084)]
        public string Name { get; set; }

        [StringLength(2084)]
        public string TrailerUrl { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
