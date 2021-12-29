using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public int FamilyId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Grade { get; set; }

        public string Phone { get; set; }

        public string Passport { get; set; }

        public int RoutId { get; set; }

        public string? ImageRoute { get; set; }
   

        public virtual Family Family { get; set; }

        public virtual Route Rout { get; set; }

    
    }
}
