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

        public int UserId { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<Family> Families { get; set; }
    }
}
