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
    public class User : IEntitiy
    {
        public User()
        {
            this.Homes = new HashSet<Home>();
            this.UserMedias = new HashSet<UserMedia>();
            this.Tickets = new HashSet<Ticket>();
        }
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? LastLogin { get; set; }
        [DefaultValue(false)]
        public bool isActive { get; set; }
        public Guid ActivationCode { get; set; }
       

        public ICollection<UserMedia> UserMedias { get; set; }
        public ICollection <Home> Homes { get; set; }
        public ICollection <Ticket> Tickets { get; set; }
    }
}
