  
namespace TailwindTraders.Api.Core.Services.Interfaces
{
    public interface IComputerVisionAnalyzer
    {
        Task<IEnumerable<string>> AnalyzeImageAsync(Stream imageStream, CancellationToken cancellationToken = default);
    }
}