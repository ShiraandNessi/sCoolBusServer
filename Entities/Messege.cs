using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Messege
    {
        public int Id { get; set; }
        public int? MessageTypeId { get; set; }
        public int DriverId { get; set; }
        public string MessageText { get; set; }
        public int RoutId { get; set; }
        public int UserId { get; set; }
        public bool? IsRead { get; set; }
        public int? StudentId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual MessageType MessageType { get; set; }
        public virtual Student Student { get; set; }
        public virtual User User { get; set; }
    }
}
