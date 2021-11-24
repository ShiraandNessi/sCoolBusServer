using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Student
    {
        public Student()
        {
            StudentStatuses = new HashSet<StudentStatus>();
        }

        public int Id { get; set; }
        public int FamilyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public int RoutId { get; set; }
        public string ImageRoute { get; set; }

        public virtual Family Family { get; set; }
        public virtual Route Rout { get; set; }
        public virtual ICollection<StudentStatus> StudentStatuses { get; set; }
    }
}
