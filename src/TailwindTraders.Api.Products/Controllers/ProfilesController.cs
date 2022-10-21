using TailwindTraders.Api.Core.Models.Implementations.Dao;

namespace TailwindTraders.Api.Products.Controllers;

[Route("v1/[controller]")]
public class ProfilesController : TailwindTradersControllerBase
{
    public ProfilesController(IMediator mediator) : base(mediator)
    {
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProfiles()      
    {     
        var request = new GetProfilesRequest();
        return await ProcessHttpRequestAsync(request);
    }
    [HttpGet("me")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProfile()
    {
        var emailid = "admin@tailwindtraders.com";
        var request = new GetProfileRequest
        {
            Email = emailid
        };
        return await ProcessHttpRequestAsync(request);
    }

}

