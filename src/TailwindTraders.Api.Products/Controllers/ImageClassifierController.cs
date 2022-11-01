namespace TailwindTraders.Api.Products.Controllers;

[Route("v1/[controller]")]
public class ImageClassifierController : TailwindTradersControllerBase
{
    internal readonly IProductService productService;
    internal readonly IImageSearchService imageSearchService;

    public ImageClassifierController(
        IProductService productService,
        IImageSearchService imageSearchService,
        IMediator mediator):base(mediator)
    {
        this.productService = productService;
        this.imageSearchService = imageSearchService;
    }

    [HttpPost("v1/products/imageclassifier")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> PostImage(IFormFile file)
    {
        var products = await imageSearchService.GetProducts(file.OpenReadStream());
        if (products.SearchResults.Any())
        {
            return Ok(products.SearchResults);
        }
        else
        {
            return NotFound($"No results found for \"{products.PredictedSearchTerm}\"");
        }
    }
}
