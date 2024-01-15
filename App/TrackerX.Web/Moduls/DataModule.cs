using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Data.Repositories;
using TrackerX.Domain.Entities.Repositories;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Web.Moduls
{
    public static class DataModule
    {
        public static void AddDataAccess(this IServiceCollection services, string connection)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlServer(connection));

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddTransient<IBandRepository, BandRepository>();
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<IExerciseRepository, ExerciseRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IInvitationRepository, InvitationRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
        }
    }
}
