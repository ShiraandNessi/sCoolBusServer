using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Driver
    {
        public Driver()
        {
            Messeges = new HashSet<Messege>();
            Routes = new HashSet<Route>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
       
        public int? UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Messege> Messeges { get; set; }
        [JsonIgnore]
        public virtual ICollection<Route> Routes { get; set; }
    }
}
