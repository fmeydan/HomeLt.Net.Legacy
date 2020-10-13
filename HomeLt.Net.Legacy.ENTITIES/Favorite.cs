using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.ENTITIES
{
    public class Favorite
    {
        public int HomeId { get; set; }
        public int UserId { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("HomeId")]
        public Home Home { get; set; }
    }
}
