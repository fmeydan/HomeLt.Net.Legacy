using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int HomeId { get; set; }
        public int UserId { get; set; }
        public string TicketCode { get; set; }
        [DefaultValue(false)]
        public bool isWin { get; set; }

        //navigation
        [ForeignKey("HomeId")]
        public virtual Home Home { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
