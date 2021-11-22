using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Messege
    {
        public int MessegeId { get; set; }
        public int? MessageTypeId { get; set; }
        public int DriverId { get; set; }
        public string MessageText { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual MessageType MessageType { get; set; }
    }
}
