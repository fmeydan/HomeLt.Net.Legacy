using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.ENTITIES
{
   public class PropertyAdress : IEntitiy
    {

        [Key]
        public int PropertyAdressId { get; set; }
        public int DistrictId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }

        //navigation
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        
    }
}
