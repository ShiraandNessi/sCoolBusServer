using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Messege
    {
        public int Id { get; set; }
        public int? MessageTypeId { get; set; }
        public int DriverId { get; set; }
        public string? MessageText { get; set; }
        public int RoutId { get; set; }
        public int UserId { get; set; }
        public bool? IsRead { get; set; }
        public int? StudentId { get; set; }
        [JsonIgnore]
        public virtual Driver Driver { get; set; }
        [JsonIgnore]
        public virtual MessageType MessageType { get; set; }
        [JsonIgnore]
        public virtual Student Student { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
