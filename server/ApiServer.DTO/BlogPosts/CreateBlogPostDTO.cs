using ApiServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.DTO.BlogPosts
{
    public class CreateBlogPostDTO : IDTO
    {
        public string Title { get; set; }
        public string ImageLocation { get; set; }
        public Guid AuthorId { get; set; }
        public string PostContent { get; set; }
        //Tags?
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public int Version { get; set; }
    }
}
