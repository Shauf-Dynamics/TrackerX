using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Data.Repositories;
using TrackerX.Domain.Entities.Repositories;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Host.Moduls
{
    public class DataAccessModule
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("dev");
            //var connectionString = builder.Configuration.GetConnectionString("prod");

            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            builder.Services.AddTransient<IBandRepository, BandRepository>();
            builder.Services.AddTransient<IMusicRepository, MusicRepository>();
            builder.Services.AddTransient<IAlbumRepository, AlbumRepository>();
            builder.Services.AddTransient<ILessonRepository, LessonRepository>();
            builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IInvitationRepository, InvitationRepository>();
        }
    }
}
