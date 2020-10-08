using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.ENTITIES
{
    public class UserMedia
    {
        [Key]
        public int UserMediaId { get; set; }
        public int UserId { get; set; }
        public string Path { get; set; }

        //navigation
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
