using MediatR;


namespace ApiServer.Domain.Entities.BlogPost
{
    public record CreateBlogPostCommand(Model.BlogPost Model) : IRequest<Guid>;

}
