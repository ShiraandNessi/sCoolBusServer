using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{//
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
        [Phone]
       
        public string Phone { get; set; }
      
        public string Passport { get; set; }
       
        public int RoutId { get; set; }
        
        public string? ImageRoute { get; set; }
        public string? Image { get; set; }

        [JsonIgnore]
        public virtual Family Family { get; set; }
        [JsonIgnore]
        public virtual Route Rout { get; set; }
        [JsonIgnore]
        public virtual ICollection<Messege> Messeges { get; set; }
        [JsonIgnore]
        public virtual ICollection<StudentStatus> StudentStatuses { get; set; }
    }
}
