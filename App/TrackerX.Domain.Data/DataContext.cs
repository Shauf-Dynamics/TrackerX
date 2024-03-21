using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Data.Configurations;
using TrackerX.Domain.Entities;
using TrackerX.UserAccessor;

namespace TrackerX.Domain.Infrastructure;

public class DataContext : DbContext
{
    private readonly IApplicationUserAccessor _applicationUserAccessor;

    public DataContext(DbContextOptions<DataContext> options, IApplicationUserAccessor applicationUserAccessor) : base(options) 
    {
        _applicationUserAccessor = applicationUserAccessor;
    }

    public DbSet<Exercise> Exercises { get; set; }

    public DbSet<ExerciseType> ExerciseTypes { get; set; }

    public DbSet<Band> Bands { get; set; }

    public DbSet<Song> Songs { get; set; }

    public DbSet<CustomMusic> CustomMusics { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<Album> Albums { get; set; }

    public DbSet<Lesson> Lessons { get; set; }

    public DbSet<TempoType> TempoTypes { get; set; }

    public DbSet<RoleType> RoleTypes { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Invitation> Invitations { get; set; }

    public DbSet<MusicProfile> MusicProfiles { get; set; }

    public DbSet<Proposal> Proposals { get; set; }

    public DbSet<ProposalStatus> ProposalStatuses{ get; set; }    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ExerciseConfiguration());
        builder.ApplyConfiguration(new ExerciseTypeConfiguration());
        builder.ApplyConfiguration(new BandConfiguration());
        builder.ApplyConfiguration(new SongConfiguration());          
        builder.ApplyConfiguration(new CustomMusicConfiguration());
        builder.ApplyConfiguration(new GenreConfiguration());
        builder.ApplyConfiguration(new AlbumConfiguration());
        builder.ApplyConfiguration(new LessonConfiguration());
        builder.ApplyConfiguration(new TempoTypeConfiguration());
        builder.ApplyConfiguration(new RoleTypeConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new InvitationConfiguration());
        builder.ApplyConfiguration(new MusicProfileConfiguration());
        builder.ApplyConfiguration(new ProposalConfiguration());
        builder.ApplyConfiguration(new ProposalStatusConfiguration());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var currentUserId = _applicationUserAccessor.GetUserId();
        var today = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries().Where(e => 
            e.State == EntityState.Added ||
            e.State == EntityState.Modified ||
            e.State == EntityState.Deleted))
        {
            entry.Property("ModifiedDateTimeUtc").CurrentValue = today; 
            entry.Property("ModifiedByUserId").CurrentValue = currentUserId;
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedDateTimeUtc").CurrentValue = today;
                entry.Property("CreatedByUserId").CurrentValue = currentUserId;
            }                       
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}