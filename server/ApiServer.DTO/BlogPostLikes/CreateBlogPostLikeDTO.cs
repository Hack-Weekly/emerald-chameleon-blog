using ApiServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.DTO.BlogPostLikes
{
    public class CreateBlogPostLikeDTO : IDTO
    {
        public Guid Id { get; set; }
        public Guid BlogPostId { get; set; }
        public Guid UserId { get; set; }
    }
}
