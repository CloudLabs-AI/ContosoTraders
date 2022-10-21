using MediatR.Pipeline;
using TailwindTraders.Api.Core.Models.Implementations.Dto;

namespace TailwindTraders.Api.Core.Requests.Handlers;

internal class GetProfilesRequestHandler : IRequestPreProcessor<GetProfilesRequest>, IRequestHandler<GetProfilesRequest, IActionResult>
{
    private readonly IProfileService _profileService;   

    public GetProfilesRequestHandler(IProfileService profileService)
    {
        _profileService = profileService;       
    }


    public async Task<IActionResult> Handle(GetProfilesRequest request, CancellationToken cancellationToken)
    {
        var result = _profileService.GetAllProfiles();

        return new OkObjectResult(result);
    }
   

    public async Task Process(GetProfilesRequest request, CancellationToken cancellationToken)
    {
        var validator = new GetProfilesRequestValidator();

        await validator.ValidateAndThrowAsync(request, cancellationToken);
    }
}