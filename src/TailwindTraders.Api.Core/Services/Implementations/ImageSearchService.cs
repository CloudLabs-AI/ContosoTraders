namespace TailwindTraders.Api.Core.Services.Implementations;

internal class ImageSearchService : IImageSearchService
{
    private readonly IProductService _productService;

    private readonly IComputerVisionAnalyzer _analyzer;

    public ImageSearchService(IProductService productService, IComputerVisionAnalyzer analyzer)
    {
        _productService = productService;
        _analyzer = analyzer;
    }

    public async Task<ImageSearchResult> GetSimilarProductsAsync(Stream imageStream, CancellationToken cancellationToken = default)
    {
        var searchTerms = await _analyzer.AnalyzeImageAsync(imageStream, cancellationToken);

        var result = new ImageSearchResult();
        List<ProductDto> products = new List<ProductDto>();
        searchTerms.ToList().ForEach(term =>
        {
            var matchingProducts = _productService.GetProducts(term);
            if(matchingProducts.Any())
                products.AddRange(matchingProducts);
        });

        result.PredictedSearchTags = searchTerms;
        result.SearchResults = products.Distinct();

        return result;
    }
}