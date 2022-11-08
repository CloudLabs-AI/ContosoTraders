  
namespace TailwindTraders.Api.Core.Services.Interfaces
{
    public interface IComputerVisionService
    {
        Task<ImageAnalysisViewModel> AnalyzeImageUrl(string imageUrl, CancellationToken cancellationToken = default);
    }
}