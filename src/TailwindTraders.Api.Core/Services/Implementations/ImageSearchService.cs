namespace TailwindTraders.Api.Core.Services.Implementations;

internal class ImageSearchService : IImageSearchService
{
    private readonly IImageSearchTermPredictor _predictor;

    private readonly IProductService _productService;

    private readonly IComputerVisionAnalyzer _analyzer;

    public ImageSearchService(IImageSearchTermPredictor predictor, IProductService productService)
    {
        _predictor = predictor;
        _productService = productService;
    }

    public async Task<ImageSearchResult> GetProductsAsync(Stream imageStream, CancellationToken cancellationToken = default)
    {
        var searchTerm = await _predictor.PredictSearchTermAsync(imageStream, cancellationToken);

        var result = new ImageSearchResult
        {
            PredictedSearchTerm = searchTerm,
            SearchResults = _productService.GetProducts(searchTerm)
        };

        return result;
    }

    public async Task<ImageSearchResult> GetSimilarProductsAsync(Stream imageStream, CancellationToken cancellationToken = default)
    {
        var searchTerms = await _analyzer.AnalyzeImageAsync(imageStream, cancellationToken);

        var result = new ImageSearchResult();
        List<ProductDto> products = new List<ProductDto>();
        searchTerms.ToList().ForEach(term =>
        {
            result.PredictedSearchTerm.Concat($"{term}, ");
            products.AddRange(_productService.GetProducts(term));
        });
        
        result.SearchResults = products.Distinct();

        return result;
    }
}