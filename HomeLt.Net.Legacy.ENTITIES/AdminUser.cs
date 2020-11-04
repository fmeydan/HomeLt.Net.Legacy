using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.ENTITIES
{
   public class AdminUser
    {
        [Key]
        public int AdminId { get; set; }
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [StringLength(24)]
        public string Password { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName  { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime LastLogin { get; set; }
      
    }
}
