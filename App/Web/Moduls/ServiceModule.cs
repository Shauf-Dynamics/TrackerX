using TrackerX.Core.Infrastructure.Cryptography;
using TrackerX.Core.Services.Albums;
using TrackerX.Core.Services.Bands;
using TrackerX.Core.Services.Lessons;
using TrackerX.Core.Services.Songs;
using TrackerX.Core.Services.Accounts.Users;

namespace TrackerX.Host.Moduls
{
    public class ServiceModule
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBandService, BandService>();
            builder.Services.AddScoped<ILessonService, LessonService>();
            builder.Services.AddScoped<ISongService, SongService>();
            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddSingleton<IPasswordHashProvider, PasswordHashProvider>();
        }
    }
}
