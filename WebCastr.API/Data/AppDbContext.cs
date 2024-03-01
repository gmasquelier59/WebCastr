using Microsoft.EntityFrameworkCore;
using WebCastr.Core.Models;

namespace WebCastr.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Station>? Stations { get; set; }
    public DbSet<MountPoint>? MountPoints { get; set; }
    public DbSet<Playlist>? Playlists { get; set; }
    public DbSet<Track>? Tracks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
