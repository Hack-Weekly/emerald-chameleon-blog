using ApiServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.DTO.BlogPostComments
{
    public class CreateBlogPostCommentDTO : IDTO
    {
        public Guid UserId { get; set; }
        public Guid BlogPostId { get; set; }
        public string CommentContent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
