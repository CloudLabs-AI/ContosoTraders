namespace TailwindTraders.Api.Core.Services;

internal abstract class TailwindTradersServiceBase
{
    protected readonly IConfiguration Configuration;
    protected readonly IMapper Mapper;
    protected readonly ILogger Logger;

    protected TailwindTradersServiceBase(ILogger logger, IMapper mapper, IConfiguration configuration)
    {
        Logger = logger;
        Mapper = mapper;
        Configuration = configuration;
    }
}