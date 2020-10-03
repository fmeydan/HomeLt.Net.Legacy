using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.ENTITIES
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int DrawId { get; set; }
        public int UserId { get; set; }

        //navigation
        [ForeignKey("DrawId")]
        public virtual Draw Draw { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
