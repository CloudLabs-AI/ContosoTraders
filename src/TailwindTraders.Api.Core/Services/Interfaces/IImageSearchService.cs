namespace TailwindTraders.Api.Core.Services.Interfaces;

public interface IImageSearchService
{
    Task<ImageSearchResult> GetProductsAsync(Stream imageStream, CancellationToken cancellationToken = default);

    Task<ImageSearchResult> GetSimilarProductsAsync(Stream imageStream, CancellationToken cancellationToken = default);
}