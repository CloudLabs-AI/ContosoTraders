
namespace TailwindTraders.Api.Products.Controllers
{
   


    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class ImageClassificationController : TailwindTradersControllerBase
    {
        
        public ImageClassificationController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("imageclassifier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostImage(IFormFile file)
        {
            var request = new PostImageRequest
            {
                File = file
            };

            return await ProcessHttpRequestAsync(request);
        }
    }
}
