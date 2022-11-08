namespace TailwindTraders.Api.Core.Requests.Definitions;

public class PostImagesRequest : IRequest<IActionResult>
{
    public string imageFilePath { get; set; }
}