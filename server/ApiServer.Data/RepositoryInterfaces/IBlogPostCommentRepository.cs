using ApiServer.Model;
using ApiServer.SharedInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Data.RepositoryInterfaces
{
    public interface IBlogPostCommentRepository : IRepository<BlogPostComment>
    {
    }
}
