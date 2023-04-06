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
        public BlogPost BlogPost { get; set; }
        public User User { get; set; }
        public string CommentContent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
