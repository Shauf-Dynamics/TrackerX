using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Data.Configurations;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Record> Records { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<ExerciseType> ExerciseTypes { get; set; }

        public DbSet<Band> Bands { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Account> Users { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<TempoType> TempoTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RecordConfiguration());
            builder.ApplyConfiguration(new ExerciseConfiguration());
            builder.ApplyConfiguration(new ExerciseTypeConfiguration());
            builder.ApplyConfiguration(new BandConfiguration());
            builder.ApplyConfiguration(new SongConfiguration());
            builder.ApplyConfiguration(new AccountConfiguration());            
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new AlbumConfiguration());
            builder.ApplyConfiguration(new LessonConfiguration());
            builder.ApplyConfiguration(new TempoTypeConfiguration());
        }
    }
}