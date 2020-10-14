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
    public class User
    {
        public User()
        {
            this.Homes = new HashSet<Home>();
            this.UserMedias = new HashSet<UserMedia>();
            this.Tickets = new HashSet<Ticket>();
            this.FavoriteHomes = new HashSet<Favorite>();
        }
        [Key]
        public int UserId { get; set; }
        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? LastLogin { get; set; }
        [DefaultValue(false)]
        public bool isActive { get; set; }
        public Guid ActivationCode { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


      
       

        public virtual ICollection<UserMedia> UserMedias { get; set; }
        public virtual ICollection <Home> Homes { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Favorite> FavoriteHomes { get; set; }
    }                  
}
