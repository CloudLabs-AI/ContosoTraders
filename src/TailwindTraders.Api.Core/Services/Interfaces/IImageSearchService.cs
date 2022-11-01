namespace TailwindTraders.Api.Core.Services.Interfaces;
public interface IImageSearchService
{
    Task<ImageSearchResult> GetProducts(Stream imageStream);
}
