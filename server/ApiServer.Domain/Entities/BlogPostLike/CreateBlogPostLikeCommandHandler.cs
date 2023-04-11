using ApiServer.Data.RepositoryInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;


namespace ApiServer.Domain.Entities.BlogPostLike
{
    public class CreateBlogPostLikeCommandHandler : IRequestHandler<CreateBlogPostLikeCommand, Guid>
    {
        private readonly ILogger<CreateBlogPostLikeCommandHandler> _logger;
        private readonly IBlogPostLikeRepository _blogPostLikeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBlogPostRepository _blogPostRepository;

        public CreateBlogPostLikeCommandHandler(
            ILogger<CreateBlogPostLikeCommandHandler> logger,
            IBlogPostLikeRepository blogPostLikeRepository,
            IUserRepository userRepository,
            IBlogPostRepository blogPostRepository)
        {
            _logger = logger;
            _blogPostLikeRepository = blogPostLikeRepository;
            _userRepository = userRepository;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<Guid> Handle(CreateBlogPostLikeCommand request, CancellationToken token)
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
            var response = await _blogPostLikeRepository.CreateAsync(request.Model, token);
            return response.Id;
        }
    }
}
