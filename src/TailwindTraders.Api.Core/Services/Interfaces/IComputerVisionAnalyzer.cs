  
namespace TailwindTraders.Api.Core.Services.Interfaces
{
    public interface IComputerVisionAnalyzer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageStream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> AnalyzeImageAsync(Stream imageStream, CancellationToken cancellationToken = default);
    }
}