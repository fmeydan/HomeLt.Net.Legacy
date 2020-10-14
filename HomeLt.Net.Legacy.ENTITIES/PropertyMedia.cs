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
  public  class PropertyMedia
    {
        [Key]
        public int PropertyMediaId { get; set; }
        public int HomeId { get; set; }
        public string Path { get; set; }
        [DefaultValue(false)]
        public bool isDefault { get; set; }
        [DefaultValue(false)]
        public bool MediaType { get; set; }
        //navigation
        [ForeignKey("HomeId")]
       public virtual Home Home { get; set; }
    }
}
