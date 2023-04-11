using ApiServer.Domain.Entities.BlogPost;
using ApiServer.Domain.Entities.BlogPostLike;
using ApiServer.DTO.BlogPostLikes;
using ApiServer.DTO.BlogPosts;

namespace ApiServer.Controllers.CRUD
{
    [ApiController]
    [Route("/api/BlogPostLike")]
    public class BlogPostLikeController : ControllerBase
    {
        private readonly ILogger<BlogPostLikeController> _logger;
        private readonly IBlogPostLikeRepository _blogPostLikeRepository;
        private readonly IMediator _mediator;

        public BlogPostLikeController(
    ILogger<BlogPostLikeController> logger
    , IBlogPostLikeRepository blogPostLikeRepository,
    IMediator mediator)
        {
            _logger = logger;
            _blogPostLikeRepository = blogPostLikeRepository;
            _mediator = mediator;
        }

        [HttpGet("/api/BlogPostLike/AllLikesForBlogPost/{id}", Name = "GetByBlogPostBlogPostLike")]
        public async Task<ActionResult<int>> Get(
    [FromRoute] Guid id,
    CancellationToken token)
        {
            var response = (await _mediator.Send(new GetByBlogPostIdBlogPostLikeQuery(id), token)).FirstOrDefault();
            return Ok(response);
        }

        [HttpGet("/api/BlogPostLike/BlogPostLikeByUserIdBlogPostId/{userId}/{blogId}", Name = "GetByUserIdBlogPostIdBlogPostLike")]
        public async Task<ActionResult<int>> Get(
[FromRoute] Guid userId,
[FromRoute] Guid blogPostId,
CancellationToken token)
        {
            var response = (await _mediator.Send(new GetByUserIdBlogPostIdBlogPostLikeQuery(userId, blogPostId), token)).FirstOrDefault();
            return Ok(response);
        }

        [HttpPost(Name = "PostBlogPostLike")]
        [ProducesResponseType(typeof(CreateBlogPostDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateBlogPostDTO>> Post(
    [FromBody] CreateBlogPostLikeDTO model,
    CancellationToken token)
        {
            var entity = model.MapToEntity<BlogPostLike>();
            var id = await _mediator.Send(new CreateBlogPostLikeCommand(entity), token);
            entity.Id = id;

            return Accepted(entity.MapToDTO<GetBlogPostLikeDTO>());
        }


        //want to implement a soft delete.

    }
}
