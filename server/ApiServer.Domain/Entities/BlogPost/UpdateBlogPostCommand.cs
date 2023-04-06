using ApiServer.DTO.BlogPosts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.BlogPost
{
    public record UpdateBlogPostCommand(Model.BlogPost model) : IRequest<Unit>;
}
