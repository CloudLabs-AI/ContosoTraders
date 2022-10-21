using MediatR.Pipeline;
using TailwindTraders.Api.Core.Models.Implementations.Dto;

namespace TailwindTraders.Api.Core.Requests.Handlers;

internal class GetProfileRequestHandler : IRequestPreProcessor<GetProfileRequest>, IRequestHandler<GetProfileRequest, IActionResult>
{
    private readonly IProfileService _profileService;

    public GetProfileRequestHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }


    public async Task<IActionResult> Handle(GetProfileRequest request, CancellationToken cancellationToken)
    {
        var profileDto = _profileService.GetProfile(request.Email);        
        return new OkObjectResult(profileDto);
    }


    public async Task Process(GetProfileRequest request, CancellationToken cancellationToken)
    {
        var validator = new GetProfileRequestValidator();

        await validator.ValidateAndThrowAsync(request, cancellationToken);
    }
}