using TrackerX.Domain.Entities;
using TrackerX.Services.Infrastructure;
using TrackerX.Services.Musics.Models;

namespace TrackerX.Services.Musics;

public interface ISongService
{
    Task<ServiceResult> CreateAsync(CreateSongModel model, int userId, string userRole);
}
