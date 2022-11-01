namespace TailwindTraders.Api.Core.Services.Implementations;

internal class ImageSearchService : IImageSearchService
{
    private readonly IImageSearchTermPredictor predictor;
    private readonly IProductService productService;

    public ImageSearchService(
        IImageSearchTermPredictor predictor, IProductService productService)
    {
        this.predictor = predictor;
        this.productService = productService;
    }

    public async Task<ImageSearchResult> GetProducts(Stream imageStream)
    {
        var searchTerm = await predictor.PredictSearchTerm(imageStream);

        var result = new ImageSearchResult {
            PredictedSearchTerm = searchTerm
        };

        var products = productService.GetProducts(searchTerm);

        var searchResults = products.Select(p => new ProductDto
        {
            Id = p.Id,
            ImageUrl = p.ImageUrl,
            Name = p.Name,
            Price = p.Price
        });
        result.SearchResults = searchResults;

        return result;
    }
}
