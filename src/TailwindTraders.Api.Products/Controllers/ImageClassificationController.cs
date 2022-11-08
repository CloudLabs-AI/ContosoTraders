
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
        public async Task<IActionResult> PostImage(string imageFilePath)
        {
            imageFilePath = @"https://tailwindtradersimg987654.blob.core.windows.net/product-details/102013777.jpg";
            var request = new PostImagesRequest
            {
                imageFilePath = imageFilePath
            };

            return await ProcessHttpRequestAsync(request);
        }
    }
}
