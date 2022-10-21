namespace TailwindTraders.Api.Core.Services.Interfaces;
using Profile = TailwindTraders.Api.Core.Models.Implementations.Dao.Profile;

internal interface IProfileService
{
    IEnumerable<Profile> GetAllProfiles();
    ProfileDto GetProfile(string emailid);
}