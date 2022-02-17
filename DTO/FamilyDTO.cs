using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FamilyDTO
    {
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
        public int UserId { get; set; }
        [MinLength(3)]
        public string Password { get; set; }

        public string Salt { get; set; }

        public int StationId { get; set; }

        public string StationAddress { get; set; }

        public double PointX { get; set; }

        public double PointY { get; set; }

    }
}
