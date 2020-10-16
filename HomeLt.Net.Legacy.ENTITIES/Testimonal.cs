using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.ENTITIES
{
    public class Testimonal
    {
        [Key]
        public int TestimonalId { get; set; }
        public int UserId { get; set; }
        public string TestimonalDescription { get; set; }
    
        //Navigation
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
