using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.BlogPostLike
{
    public record GetByUserIdBlogPostIdBlogPostLikeQuery(Guid userId, Guid blogPostId) : IRequest<IQueryable<Model.BlogPostLike>>;

}
