using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class User
    {
        public User()
        {
            Drivers = new HashSet<Driver>();
            Families = new HashSet<Family>();
        }

        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<Family> Families { get; set; }
    }
}
