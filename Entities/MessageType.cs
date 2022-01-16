using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class MessageType
    {
        public MessageType()
        {
            Messeges = new HashSet<Messege>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Messege> Messeges { get; set; }
    }
}
