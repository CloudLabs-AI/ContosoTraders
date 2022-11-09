namespace TailwindTraders.Api.Core.Services.Implementations;
public class ComputerVisionAnalyzer : IComputerVisionAnalyzer
{ 
    private string subscriptionKey = "e355a2abe59048afad1b8045f14b8909";
    private string endpoint = "https://eastus.api.cognitive.microsoft.com/";

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
        ComputerVisionClient client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
        {
            Endpoint = endpoint
        };
        return client;
    }
}
