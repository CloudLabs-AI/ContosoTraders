using MediatR.Pipeline;

namespace TailwindTraders.Api.Core.Requests.Handlers;

internal class PostImageRequestHandler : IRequestPreProcessor<PostImageRequest>, IRequestHandler<PostImageRequest, IActionResult>
{
    private readonly IProductService _productService;
    private readonly IImageSearchService _imageSearchService;

    public PostImageRequestHandler(IProductService productService, IImageSearchService imageSearchService)
    {
        _productService = productService;
        _imageSearchService = imageSearchService;
    }

    public async Task<IActionResult> Handle(PostImageRequest request, CancellationToken cancellationToken)
    {
        var products = await _imageSearchService.GetProducts(request.File.OpenReadStream());
        if (products.SearchResults.Any())
        {
            return new OkObjectResult(products.SearchResults);
        }
        else
        {
            return new ObjectResult($"No results found matching : {products.PredictedSearchTerm}") { StatusCode = 404 };
        }
    }

    public async Task Process(PostImageRequest request, CancellationToken cancellationToken)
    {
        var validator = new PostImageRequestValidator();

        await validator.ValidateAndThrowAsync(request, cancellationToken);
    }
}