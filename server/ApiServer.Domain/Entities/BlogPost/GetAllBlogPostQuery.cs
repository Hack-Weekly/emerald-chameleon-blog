using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.BlogPost
{

    public record GetAllBlogPostQuery() : IRequest<IQueryable<Model.BlogPost>>;
}
