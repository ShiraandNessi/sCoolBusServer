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

        public string FamilyName { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public string MotherPhone { get; set; }
        public string FatherPhone { get; set; }
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
