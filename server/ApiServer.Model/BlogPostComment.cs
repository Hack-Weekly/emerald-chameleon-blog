using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Model
{
    public class BlogPostComment : IEntity
    {
        public Guid Id { get; set; }
        public BlogPost BlogPost { get; set; }
        public Guid BlogPostId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string CommentContent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
