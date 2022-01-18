using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Entities
{
    public partial class Family
    {
        public Family()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public string FamilyName { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        [Phone]
        public string MotherPhone { get; set; }
        [Phone]
        public string FatherPhone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
     
        public bool EnableMotherWhatsApp { get; set; }
       
        public bool EnableFatherWhatsApp { get; set; }
        public int StationId { get; set; }
       
        public int? UserId { get; set; }
        
        public virtual Station Station { get; set; }
        
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}
