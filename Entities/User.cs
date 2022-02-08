using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class User
    {
        public User()
        {
            Drivers = new HashSet<Driver>();
            Families = new HashSet<Family>();
            Messeges = new HashSet<Messege>();
        }

        public int Id { get; set; }
        [MinLength(3)]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int UserTypeId { get; set; }

        public virtual UserType UserType { get; set; }
        [JsonIgnore]
        public virtual ICollection<Driver> Drivers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Family> Families { get; set; }
        [JsonIgnore]
        public virtual ICollection<Messege> Messeges { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
