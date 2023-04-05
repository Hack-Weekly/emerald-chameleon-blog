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

        public CreateBlogPostCommandHandler(
            ILogger<CreateBlogPostCommandHandler> logger,
            IBlogPostRepository blogPostRepository)
        {
            _logger = logger;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<Guid> Handle(CreateBlogPostCommand request, CancellationToken token)
        {
            var response = await _blogPostRepository.CreateAsync(request.Model, token);
            return response.Id;
        }
    }
}
