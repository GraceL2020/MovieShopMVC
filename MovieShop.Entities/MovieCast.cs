using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{
    [Table("MovieCast")]
    public class MovieCast
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CastId { get; set; }

        [Key]
        [Required]
        [Column(Order = 2)]
        [StringLength(450)]
        public string Character { get; set; }

        public Movie Movie { get; set; }

        public Cast Cast { get; set; }
    }
}
