namespace TailwindTraders.Api.Core.Services.Interfaces;

public interface IImageSearchTermPredictor
{
    Task<string> PredictSearchTerm(Stream imageStream);
}
