using ApiServer.Data.RepositoryInterfaces;
using ApiServer.SharedInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.BlogPost
{
    public class UpdateBlogPostCommandHandler : IRequestHandler<UpdateBlogPostCommand, Unit>
    {
        private readonly ILogger<UpdateBlogPostCommandHandler> _logger;
        private readonly IBlogPostRepository _blogRepository;
        private readonly IUserRepository _userRepository;

        public UpdateBlogPostCommandHandler(
            ILogger<UpdateBlogPostCommandHandler> logger,
            IBlogPostRepository repository,
            IUserRepository userRepository)
        {
            _logger = logger;
            _blogRepository = repository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
        {
            var author = _userRepository.Get().Where(x => x.Id == request.model.AuthorId).FirstOrDefault();
            if(author is null)
            {
                throw new KeyNotFoundException($@"No author found for Id {request.model.AuthorId}");
            }
            request.model.Author = author;
            await _blogRepository.UpdateAsync(request.model, cancellationToken);
            return Unit.Value;
        }
    }
}
