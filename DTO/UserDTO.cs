using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class UserDTO
    {//
        [EmailAddress]
        public string? Email { get; set; }
        [MinLength(3)]
        public string? NewPassword { get; set; }
        public string Password { get; set; }
        //public string Token { get; set; }
    }
}
