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
    public class GetAllBlogPostQueryHandler : IRequestHandler<GetAllBlogPostQuery, IQueryable<Model.BlogPost>>
    {
        private ILogger<GetAllBlogPostQueryHandler> _logger;
        private readonly IBlogPostRepository _blogPostRepository;

        public GetAllBlogPostQueryHandler(
            ILogger<GetAllBlogPostQueryHandler> logger,
            IBlogPostRepository blogPostRepository)
        {
            _logger = logger;
            _blogPostRepository = blogPostRepository;
        }

        public Task<IQueryable<Model.BlogPost>> Handle(GetAllBlogPostQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_blogPostRepository.Get());
        }
    }
}
