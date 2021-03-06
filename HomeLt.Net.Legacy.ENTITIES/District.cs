﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.ENTITIES
{
   public class District
    {
       
        public string Name { get; set; }
        [Key]
        public int CityId { get; set; }

        //navigation
       [ForeignKey("CityId")]
       public virtual City City { get; set; }
    }
}
