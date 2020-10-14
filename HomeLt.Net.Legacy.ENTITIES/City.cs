using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.ENTITIES
{
    public class City
    {
        public City()
        {
            this.Districts = new HashSet<District>();
        }
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }

        //navigation
        public virtual ICollection<District> Districts { get; set; }

    }
}
