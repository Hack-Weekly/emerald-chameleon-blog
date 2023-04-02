using ApiServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.DTO.Users
{
    public class TokenValidationResponseDTO
    {
        public int Id { get; set; }

        public User? User { get; set; }

        public TokenValidationResponseDTO(User user)
        {
            User = user;
        }
    }
}
