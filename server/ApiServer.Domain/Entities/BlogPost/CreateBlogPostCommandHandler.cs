using ApiServer.Data.RepositoryInterfaces;
using ApiServer.Domain.Entities.WeatherForecast;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.BlogPost
{
    public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, Guid>
    {
        private readonly ILogger<CreateBlogPostCommandHandler> _logger;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IUserRepository _userRepository;

        public CreateBlogPostCommandHandler(
            ILogger<CreateBlogPostCommandHandler> logger,
            IBlogPostRepository blogPostRepository,
            IUserRepository userRepository)
        {
            _logger = logger;
            _blogPostRepository = blogPostRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateBlogPostCommand request, CancellationToken token)
        {
            var author = _userRepository.Get().Where(x => x.Id == request.Model.AuthorId).FirstOrDefault();
            if (author is null)
            {
                throw new KeyNotFoundException($@"No author found for Id {request.Model.AuthorId}");
            }
            request.Model.Author = author;
            var response = await _blogPostRepository.CreateAsync(request.Model, token);
            return response.Id;
        }
    }
}
