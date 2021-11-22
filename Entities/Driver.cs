using System;
using System.Collections.Generic;

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

        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Messege> Messeges { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
