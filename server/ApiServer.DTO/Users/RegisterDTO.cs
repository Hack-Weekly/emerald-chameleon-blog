using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.DTO.Users
{
    public class RegisterDTO : IDTO
    {
        public string? Name { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; } = string.Empty;
        
        public string? Mobile { get; set; }

        [Required] 
        public string Username { get; set; } = string.Empty;

        [Required] 
        public string Password { get; set; } = string.Empty;
    }
}
