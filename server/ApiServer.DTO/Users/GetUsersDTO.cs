using ApiServer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.DTO.Users
{
    public class GetUsersDTO : IDTO
    {
        public Guid Id { get; set; }
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Mobile { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public bool? isConfirmed { get; set; } = false;

        public RoleLevels UserRole { get; set; } = RoleLevels.Reader;


        public ICollection<BlogPost> BlogPosts { get; set; }
        public ICollection<BlogPostComment> BlogPostsComments { get; set; }
        public ICollection<BlogPostLike> BlogPostLikes { get; set; }
    }
}
