using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.User
{
    public record GetAllUsersQuery() : IRequest<IQueryable<Model.User>>;
}
