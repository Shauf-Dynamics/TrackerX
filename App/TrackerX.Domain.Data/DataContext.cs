using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Data.Configurations;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<ExerciseType> ExerciseTypes { get; set; }

        public DbSet<Band> Bands { get; set; }

        public DbSet<Music> Songs { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<TempoType> TempoTypes { get; set; }

        public DbSet<RoleType> RoleTypes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ExerciseConfiguration());
            builder.ApplyConfiguration(new ExerciseTypeConfiguration());
            builder.ApplyConfiguration(new BandConfiguration());
            builder.ApplyConfiguration(new MusicConfiguration());          
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new AlbumConfiguration());
            builder.ApplyConfiguration(new LessonConfiguration());
            builder.ApplyConfiguration(new TempoTypeConfiguration());
            builder.ApplyConfiguration(new RoleTypeConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new InvitationConfiguration());
        }
    }
}