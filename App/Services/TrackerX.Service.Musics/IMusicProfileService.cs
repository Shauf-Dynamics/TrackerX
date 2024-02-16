using TrackerX.Service.Musics.Models;

namespace TrackerX.Service.Musics;

public interface IMusicProfileService
{
    Task<IEnumerable<MusicProfileView>> GetUserOwnMusic(MusicProfilesSearchModel searchModel);
}
