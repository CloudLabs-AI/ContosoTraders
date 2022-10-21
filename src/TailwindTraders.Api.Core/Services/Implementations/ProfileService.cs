namespace TailwindTraders.Api.Core.Services.Implementations;

using TailwindTraders.Api.Core.Models.Implementations.Dto;


internal class ProfileService : TailwindTradersServiceBase, IProfileService
{
    private readonly ProfilesDbContext _profileRepository;

    public ProfileService(ProfilesDbContext profileRepository, IMapper mapper, IConfiguration configuration) : base(mapper, configuration)
    {
        _profileRepository = profileRepository;
    }
    public IEnumerable<Models.Implementations.Dao.Profile> GetAllProfiles()
    {
        return _profileRepository.Profiles.ToList();
    }
    public ProfileDto GetProfile(string emailid)
    {
        var profileDao = _profileRepository.Profiles.SingleOrDefault(profile => profile.Email == emailid);      
        var profileDto = Mapper.Map<ProfileDto>(profileDao);
        return profileDto;
    }
    
}