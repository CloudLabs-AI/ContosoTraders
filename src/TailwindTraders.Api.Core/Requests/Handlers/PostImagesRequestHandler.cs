using MediatR.Pipeline;

namespace TailwindTraders.Api.Core.Requests.Handlers;

 internal class PostImagesRequestHandler : IRequestPreProcessor<PostImagesRequest>, IRequestHandler<PostImagesRequest, IActionResult>
{
    private readonly IComputerVisionService _imageSearchService;

    public PostImagesRequestHandler(IComputerVisionService imageSearchService)
    {
        _imageSearchService = imageSearchService;
    }

    public async Task<IActionResult> Handle(PostImagesRequest request, CancellationToken cancellationToken = default)
    {
        var products = await _imageSearchService.AnalyzeImageUrl(request.imageFilePath, cancellationToken);
        return new OkObjectResult(products);
    }
    

    public async Task Process(PostImagesRequest request, CancellationToken cancellationToken)
    {
        var validator = new PostImagesRequestValidator();

        await validator.ValidateAndThrowAsync(request, cancellationToken);
    }
}

