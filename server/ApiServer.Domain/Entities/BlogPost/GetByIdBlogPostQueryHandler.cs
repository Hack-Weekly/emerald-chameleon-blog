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
    public class GetByIdBlogPostQueryHandler : IRequestHandler<GetByIdBlogPostQuery, IQueryable<Model.BlogPost>>
    {

        private readonly ILogger<GetByIdBlogPostQueryHandler> _logger;
        private readonly IBlogPostRepository _blogPostRepository;
        public GetByIdBlogPostQueryHandler(ILogger<GetByIdBlogPostQueryHandler> logger, IBlogPostRepository repository)
        {
            _logger = logger;
            _blogPostRepository = repository;
        }


        public Task<IQueryable<Model.BlogPost>> Handle(GetByIdBlogPostQuery request, CancellationToken token)
        {
            return Task.FromResult(_blogPostRepository.Get(request.id));
        }
    }
}
