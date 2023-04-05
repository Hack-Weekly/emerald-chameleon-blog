using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Data.EF.EntityRepositories
{
    public class BlogPostLikeRepository : BaseRepository<BlogPostLike>, IBlogPostLikeRepository
    {
        private readonly MainDbContext _context;

        public BlogPostLikeRepository(MainDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
