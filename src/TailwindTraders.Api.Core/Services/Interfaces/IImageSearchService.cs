namespace TailwindTraders.Api.Core.Services.Interfaces;

public interface IImageSearchService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="imageStream"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ImageSearchResult> GetSimilarProductsAsync(Stream imageStream, CancellationToken cancellationToken = default);
}