namespace TailwindTraders.Api.Core.Services.Implementations;
internal class ComputerVisionAnalyzer : TailwindTradersServiceBase, IComputerVisionAnalyzer
{ 

    public ComputerVisionAnalyzer(IMapper mapper, IConfiguration configuration):base(mapper, configuration) { }

    public async Task<IEnumerable<string>> AnalyzeImageAsync(Stream imageStream, CancellationToken cancellationToken = default)
    {
        ComputerVisionClient client = Authenticate();
        List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() {
                    VisualFeatureTypes.Tags
            };
        ImageAnalysis results = await client.AnalyzeImageInStreamAsync(imageStream, visualFeatures: features);
        var searchTerms = results.Tags.Select(tag => tag.Name).ToList();
        return searchTerms;
    }

    private ComputerVisionClient Authenticate()
    {
        ComputerVisionClient client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(Configuration[KeyVaultConstants.SecretNameCognitiveServicesAccountKey]))
        {
            Endpoint = Configuration[KeyVaultConstants.SecretNameCognitiveServicesEndpoint]
        };
        return client;
    }
}
