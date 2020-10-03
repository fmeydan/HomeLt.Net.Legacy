using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.ENTITIES
{
   public class PropertyAdress
    {
        [Key]
        public int PropertyAdressId { get; set; }
        public int HomeId { get; set; }
        public int DistrictId { get; set; }
        public string Descrpiton { get; set; }
        public string ZipCode { get; set; }

        //navigation
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        [ForeignKey("HomeId")]
        public virtual Home Home { get; set; }
    }
}
