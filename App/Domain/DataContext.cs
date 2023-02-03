using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Record> Records { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RecordConfiguration());
            builder.ApplyConfiguration(new ExerciseConfiguration());
        }
    }
}