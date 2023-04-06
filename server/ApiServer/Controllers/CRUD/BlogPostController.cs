using ApiServer.Domain.Entities.BlogPost;
using ApiServer.DTO.BlogPosts;
using Microsoft.AspNetCore.Authorization;

namespace ApiServer.Controllers.CRUD
{
    [ApiController]
    [Route("/api/BlogPost")]
    public class BlogPostController : ControllerBase 
    {
        private readonly ILogger<BlogPostController> _logger;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMediator _mediator;

        public BlogPostController(
    ILogger<BlogPostController> logger
    , IBlogPostRepository blogPostRepository,
    IMediator mediator)
        {
            _logger = logger;
            _blogPostRepository = blogPostRepository;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetBlogPosts")]
        public async Task<ActionResult<IEnumerable<GetBlogPostDTO>>> Get(CancellationToken token)
        {
            var response = await _mediator.Send(new GetAllBlogPostQuery(), token);
            return Ok(response.ToList().MapToDTO<IEnumerable<GetBlogPostDTO>>());
        }

        [HttpGet("/api/BlogPost/{id}", Name = "GetByIdBlogPost")]
        public async Task<ActionResult<GetBlogPostDTO>> Get(
    [FromRoute] Guid id,
    CancellationToken token)
        {
            var response = (await _mediator.Send(new GetByIdBlogPostQuery(id), token)).FirstOrDefault();
            return Ok(response.MapToDTO<GetBlogPostDTO>());
        }

        [HttpPost(Name = "PostBlogPost")]
        [ProducesResponseType(typeof(CreateBlogPostDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateBlogPostDTO>> Post(
    [FromBody] CreateBlogPostDTO model,
    CancellationToken token)
        {
            var entity = model.MapToEntity<BlogPost>();
            var id = await _mediator.Send(new CreateBlogPostCommand(entity), token);
            entity.Id = id;

            return Accepted(entity.MapToDTO<GetBlogPostDTO>());
        }

        [HttpPut(Name = "PutBlogPost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Put(UpdateBlogPostDTO model, CancellationToken token)
        {
            var entity = model.MapToEntity<BlogPost>();
            var result = await _mediator.Send(new UpdateBlogPostCommand(entity), token);
            return Accepted(result);
        }

        //want to implement a soft delete.
        //[HttpDelete(Name = "DeleteByIdBlogPost")]

    }
}
