using ApiServer.Data.RepositoryInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.BlogPostComment
{
    public class GetAllBlogPostCommentQueryHandler : IRequestHandler<GetAllBlogPostCommentQuery, IQueryable<Model.BlogPostComment>>
    {
        private ILogger<GetAllBlogPostCommentQueryHandler> _logger;
        private readonly IBlogPostCommentRepository _blogPostCommentRepository;

        public GetAllBlogPostCommentQueryHandler(
            ILogger<GetAllBlogPostCommentQueryHandler> logger,
            IBlogPostCommentRepository blogPostCommentRepository)
        {
            _logger = logger;
            _blogPostCommentRepository = blogPostCommentRepository;
        }

        public Task<IQueryable<Model.BlogPostComment>> Handle(GetAllBlogPostCommentQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_blogPostCommentRepository.Get());
        }
    }
}
