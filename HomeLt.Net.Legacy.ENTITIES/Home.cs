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
    public class Home : IEntitiy
    {
        public Home()
        {
            this.PropertyMedias = new HashSet<PropertyMedia>();
        }
        [Key]
        public int HomeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short RoomNumber { get; set; }
        public short PropertyType { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        [DefaultValue(true)]
        public bool isAvaible { get; set; }

        //navigation
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("AddressId")]
        public virtual PropertyAdress Address { get; set; }

        public ICollection<PropertyMedia> PropertyMedias { get; set; }


    }
}
