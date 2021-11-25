using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public int FamilyId { get; set; }
        [JsonIgnore]
        public string FirstName { get; set; }
        [JsonIgnore]
        public string LastName { get; set; }
        [JsonIgnore]
        public int Grade { get; set; }
        [JsonIgnore]
        public string Phone { get; set; }
        [JsonIgnore]
        public string Passport { get; set; }
        [JsonIgnore]
        public int RoutId { get; set; }
        [JsonIgnore]
        public string ImageRoute { get; set; }
        [JsonIgnore]

        public virtual Family Family { get; set; }
        [JsonIgnore]
        public virtual Route Rout { get; set; }
        [JsonIgnore]
        public virtual ICollection<StudentStatus> StudentStatuses { get; set; }
    }
}
