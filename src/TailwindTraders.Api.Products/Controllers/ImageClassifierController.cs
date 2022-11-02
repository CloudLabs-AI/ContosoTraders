namespace TailwindTraders.Api.Products.Controllers;

public class ImageClassifierController : TailwindTradersControllerBase
{
    public ImageClassifierController(IMediator mediator) : base(mediator) { }

    [HttpPost("v1/Products/imageclassifier")]
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
