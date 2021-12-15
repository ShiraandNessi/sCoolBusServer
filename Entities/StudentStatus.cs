using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class StudentStatus
    {
        public int Id { get; set; }
        public int Studentid { get; set; }
        public int? StatusTypeId { get; set; }
        public bool? GetAlert { get; set; }
        public string GetOnImage { get; set; }
        public string GetOffImage { get; set; }

        public virtual StatusType StatusType { get; set; }
        public virtual Student Student { get; set; }
    }
}
