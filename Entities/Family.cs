using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public string FamilyName { get; set; }
        [JsonIgnore]
        public string MotherName { get; set; }
        [JsonIgnore]
        public string FatherName { get; set; }
        [JsonIgnore]
        public string Address { get; set; }
        [JsonIgnore]
        public string MotherPhone { get; set; }
        [JsonIgnore]
        public string FatherPhone { get; set; }
        [JsonIgnore]
        public string Email { get; set; }
        [JsonIgnore]
        public bool EnableMotherWhatsApp { get; set; }
        [JsonIgnore]
        public bool EnableFatherWhatsApp { get; set; }
        
        public int StationId { get; set; }
        
        public int? UserId { get; set; }
        [JsonIgnore]

        public virtual Station Station { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}
