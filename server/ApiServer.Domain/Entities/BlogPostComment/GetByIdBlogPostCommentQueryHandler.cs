using ApiServer.Data.RepositoryInterfaces;
using ApiServer.Domain.Entities.BlogPost;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.BlogPostComment
{
    public class GetByIdBlogPostCommentQueryHandler : IRequestHandler<GetByIdBlogPostCommentQuery, IQueryable<Model.BlogPostComment>>
    {

        private readonly ILogger<GetByIdBlogPostCommentQueryHandler> _logger;
        private readonly IBlogPostCommentRepository _blogPostCommentRepository;
        public GetByIdBlogPostCommentQueryHandler(ILogger<GetByIdBlogPostCommentQueryHandler> logger, IBlogPostCommentRepository repository)
        {
            _logger = logger;
            _blogPostCommentRepository = repository;
        }


        public Task<IQueryable<Model.BlogPostComment>> Handle(GetByIdBlogPostCommentQuery request, CancellationToken token)
        {
            return Task.FromResult(_blogPostCommentRepository.Get(request.id));
        }
    }
}
