using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class StatusType
    {
        public StatusType()
        {
            StudentStatuses = new HashSet<StudentStatus>();
        }

        public int StatusTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<StudentStatus> StudentStatuses { get; set; }
    }
}
