namespace TailwindTraders.Api.Core.Requests.Definitions;

public class PostFileRequest : IRequest<IActionResult>
{
    public IFormFile File { get; set; }
}