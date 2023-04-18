﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.BlogPostComment
{
    public record GetAllBlogPostCommentQuery() : IRequest<IQueryable<Model.BlogPostComment>>;
}
