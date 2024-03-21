using TrackerX.Service.Musics.Models;
using TrackerX.Services.Infrastructure;

namespace TrackerX.Service.Musics;

public interface ICustomMusicService
{
    Task<ServiceResult> CreateAsync(CreateCustomMusicModel cusomMusic, int userId, string userRole);
}
