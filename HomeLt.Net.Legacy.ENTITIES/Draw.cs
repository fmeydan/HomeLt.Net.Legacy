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
   public class Draw : IEntitiy
    {
        [Key]
        public int DrawId { get; set; }
        public int HomeId { get; set; }
        [DefaultValue(false)]
        public bool isComplated { get; set; }
        

        //navigation
        [ForeignKey("HomeId")]
        public virtual Home Home { get; set; }

        
    }
}
