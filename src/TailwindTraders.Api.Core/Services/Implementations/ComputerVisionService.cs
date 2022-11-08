using TailwindTraders.Api.Core.Models.Implementations.Dto;  
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;  
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;  
using System.Collections.Generic;  
using System.IO;  
using System.Threading.Tasks;  
namespace TailwindTraders.Api.Core.Services.Implementations
{
    public class ComputerVisionService : IComputerVisionService
    {
        // Add your Computer Vision subscription key and endpoint    
        private string subscriptionKey = "e355a2abe59048afad1b8045f14b8909";
        private string endpoint = "https://eastus.api.cognitive.microsoft.com/";
        /*  
         * AUTHENTICATE  
         * Creates a Computer Vision client used by each example.  
         */
        public ComputerVisionClient Authenticate()
        {
            ComputerVisionClient client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
            {
                Endpoint = endpoint
            };
            return client;
        }
        public async Task<ImageAnalysisViewModel> AnalyzeImageUrl(string imageUrl, CancellationToken cancellationToken = default)
        {
            try
            {
                // Creating a list that defines the features to be extracted from the image.     
                ComputerVisionClient client = Authenticate();
                List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() {
                    VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
                        VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
                        VisualFeatureTypes.Tags, VisualFeatureTypes.Adult,
                        VisualFeatureTypes.Color, VisualFeatureTypes.Brands,
                        VisualFeatureTypes.Objects
                };
                ImageAnalysis results;
                using (Stream imageStream = File.OpenRead(imageUrl))
                {
                    results = await client.AnalyzeImageInStreamAsync(imageStream, visualFeatures: features);
                    //imageStream.Close();    
                }
                ImageAnalysisViewModel imageAnalysis = new ImageAnalysisViewModel();
                imageAnalysis.imageAnalysisResult = results;
                return imageAnalysis;
            }
            catch (System.Exception ex)
            {
                // add your log capture code    
                throw;
            }
        }
    }
}