using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.ENTITIES
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }
        public int HomeId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("HomeId")]
        public virtual Home Home { get; set; }
    }
}
