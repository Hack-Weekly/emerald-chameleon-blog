using ApiServer.Data.RepositoryInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;


namespace ApiServer.Domain.Entities.BlogPostComment
{
    public class CreateBlogPostCommentCommandHandler : IRequestHandler<CreateBlogPostCommentCommand, Guid>
    {
        private readonly ILogger<CreateBlogPostCommentCommandHandler> _logger;
        private readonly IBlogPostCommentRepository _blogPostCommentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBlogPostRepository _blogPostRepository;

        public CreateBlogPostCommentCommandHandler(
            ILogger<CreateBlogPostCommentCommandHandler> logger,
            IBlogPostCommentRepository blogPostCommentRepository,
            IUserRepository userRepository,
            IBlogPostRepository blogPostRepository)
        {
            _logger = logger;
            _blogPostCommentRepository = blogPostCommentRepository;
            _userRepository = userRepository;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<Guid> Handle(CreateBlogPostCommentCommand request, CancellationToken token)
        {
            var author = _userRepository.Get().Where(x => x.Id == request.Model.UserId).FirstOrDefault();
            if (author is null)
            {
                throw new KeyNotFoundException($@"No user found for Id {request.Model.UserId}");
            }

            var blogPost = _blogPostRepository.Get().Where(x => x.Id == request.Model.BlogPostId).FirstOrDefault();
            if (blogPost is null)
            {
                throw new KeyNotFoundException($@"No blog post found for Id {request.Model.BlogPostId}");
            }

            request.Model.User = author;
            request.Model.BlogPost = blogPost;
            var response = await _blogPostCommentRepository.CreateAsync(request.Model, token);
            return response.Id;
        }
    }
}
