using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.BlogPostLike
{
    public record GetByBlogPostIdBlogPostLikeQuery(Guid id) : IRequest<IQueryable<int>>
    {
    }
}
