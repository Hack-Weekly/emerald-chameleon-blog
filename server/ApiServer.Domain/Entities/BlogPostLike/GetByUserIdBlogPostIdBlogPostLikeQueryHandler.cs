using ApiServer.Data.RepositoryInterfaces;
using ApiServer.Domain.Entities.BlogPostComment;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.BlogPostLike
{
    public class GetByUserIdBlogPostIdBlogPostLikeQueryHandler : IRequestHandler<GetByUserIdBlogPostIdBlogPostLikeQuery, IQueryable<Model.BlogPostLike>>
    {

        private readonly ILogger<GetByUserIdBlogPostIdBlogPostLikeQueryHandler> _logger;
        private readonly IBlogPostLikeRepository _blogPostLikeRepository;
        public GetByUserIdBlogPostIdBlogPostLikeQueryHandler(ILogger<GetByUserIdBlogPostIdBlogPostLikeQueryHandler> logger, IBlogPostLikeRepository repository)
        {
            _logger = logger;
            _blogPostLikeRepository = repository;
        }


        public Task<IQueryable<Model.BlogPostLike>> Handle(GetByUserIdBlogPostIdBlogPostLikeQuery request, CancellationToken token)
        {
            return Task.FromResult(_blogPostLikeRepository.Get().Where(x => x.UserId == request.userId).Where(x => x.BlogPostId == request.blogPostId));
        }
    }
}
