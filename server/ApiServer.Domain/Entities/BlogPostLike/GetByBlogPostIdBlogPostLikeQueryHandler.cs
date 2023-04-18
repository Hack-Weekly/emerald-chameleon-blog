using ApiServer.Data.RepositoryInterfaces;
using ApiServer.Domain.Entities.BlogPost;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.BlogPostLike
{
    public class GetByBlogPostIdBlogPostLikeQueryHandler : IRequestHandler<GetByBlogPostIdBlogPostLikeQuery, IQueryable<int>>
    {

        private readonly ILogger<GetByBlogPostIdBlogPostLikeQueryHandler> _logger;
        private readonly IBlogPostLikeRepository _blogPostLikeRepository;
        public GetByBlogPostIdBlogPostLikeQueryHandler(ILogger<GetByBlogPostIdBlogPostLikeQueryHandler> logger, IBlogPostLikeRepository repository)
        {
            _logger = logger;
            _blogPostLikeRepository = repository;
        }


        public async Task<IQueryable<int>> Handle(GetByBlogPostIdBlogPostLikeQuery request, CancellationToken token)
        {
            var blogPostLikes = await _blogPostLikeRepository.GetCountByBlogPostId(request.id);
            return (IQueryable<int>)Task.FromResult(blogPostLikes);
        }
    }
}
