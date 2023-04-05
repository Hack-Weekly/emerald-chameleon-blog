using ApiServer.Data.RepositoryInterfaces;
using ApiServer.Domain.Entities.BlogPost;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.User
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IQueryable<Model.User>>
    {
        private ILogger<GetAllUsersQueryHandler> _logger;
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(
            ILogger<GetAllUsersQueryHandler> logger,
            IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public Task<IQueryable<Model.User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.Get());
        }
    }
}
