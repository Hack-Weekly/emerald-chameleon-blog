using ApiServer.Domain.Entities.BlogPostComment;
using ApiServer.DTO.BlogPostComments;
using ApiServer.DTO.BlogPosts;

namespace ApiServer.Controllers.CRUD
{
    [ApiController]
    [Route("/api/BlogPostComment")]
    public class BlogPostCommentController : ControllerBase
    {
        private readonly ILogger<BlogPostCommentController> _logger;
        private readonly IBlogPostCommentRepository _blogPostCommentRepository;
        private readonly IMediator _mediator;

        public BlogPostCommentController(
    ILogger<BlogPostCommentController> logger
    , IBlogPostCommentRepository blogPostCommentRepository,
    IMediator mediator)
        {
            _logger = logger;
            _blogPostCommentRepository = blogPostCommentRepository;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetBlogPostComments")]
        public async Task<ActionResult<IEnumerable<GetBlogPostCommentDTO>>> Get(CancellationToken token)
        {
            var response = await _mediator.Send(new GetAllBlogPostCommentQuery(), token);
            return Ok(response.ToList().MapToDTO<IEnumerable<GetBlogPostCommentDTO>>());
        }

        [HttpGet("/api/BlogPostComment/{id}", Name = "GetByIdBlogPostComment")]
        public async Task<ActionResult<GetBlogPostCommentDTO>> Get(
    [FromRoute] Guid id,
    CancellationToken token)
        {
            var response = (await _mediator.Send(new GetByIdBlogPostCommentQuery(id), token)).FirstOrDefault();
            return Ok(response.MapToDTO<GetBlogPostCommentDTO>());
        }

        [HttpPost(Name = "PostBlogPostComment")]
       // [EnableQuery(MaxExpansionDepth = 0)]
        [ProducesResponseType(typeof(CreateBlogPostCommentDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateBlogPostCommentDTO>> Post(
    [FromBody] CreateBlogPostCommentDTO model,
    CancellationToken token)
        {
            var entity = model.MapToEntity<BlogPostComment>();
            var id = await _mediator.Send(new CreateBlogPostCommentCommand(entity), token);
            entity.Id = id;
            return Accepted(entity.MapToDTO<GetBlogPostCommentDTO>());
        }

        //want to implement a soft delete.
        //[HttpDelete(Name = "DeleteByIdBlogPost")]

    }
}

