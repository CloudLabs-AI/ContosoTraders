namespace TailwindTraders.Api.Core.Services.Implementations;

internal class ImageAnalysisService : TailwindTradersServiceBase, IImageAnalysisService
{
    public ImageAnalysisService(IMapper mapper, IConfiguration configuration) : base(mapper, configuration)
    {
    }

    public async Task<IEnumerable<string>> AnalyzeImageAsync(Stream imageStream, CancellationToken cancellationToken = default)
    {
        var client = Authenticate();
        var features = new List<VisualFeatureTypes?>
        {
            VisualFeatureTypes.Tags
        };
        var results = await client.AnalyzeImageInStreamAsync(imageStream, features);
        var searchTerms = results.Tags.Select(tag => tag.Name).ToList();
        return searchTerms;
    }

    private ComputerVisionClient Authenticate()
    {
        var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(Configuration[KeyVaultConstants.SecretNameCognitiveServicesAccountKey]))
        {
            Endpoint = Configuration[KeyVaultConstants.SecretNameCognitiveServicesEndpoint]
        };
        return client;
    }
}