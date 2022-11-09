using MediatR.Pipeline;

namespace TailwindTraders.Api.Core.Requests.Handlers;

 internal class PostFileRequestHandler : IRequestPreProcessor<PostFileRequest>, IRequestHandler<PostFileRequest, IActionResult>
{
    private readonly IImageSearchService _imageSearchService;

    public PostFileRequestHandler(IImageSearchService imageSearchService)
    {
        _imageSearchService = imageSearchService;
    }

    public async Task<IActionResult> Handle(PostFileRequest request, CancellationToken cancellationToken = default)
    {
        var products = await _imageSearchService.GetSimilarProductsAsync(request.File.OpenReadStream(), cancellationToken);
        return new OkObjectResult(products);
    }    

    public async Task Process(PostFileRequest request, CancellationToken cancellationToken)
    {
        var validator = new PostFileRequestValidator();

        await validator.ValidateAndThrowAsync(request, cancellationToken);
    }
}

