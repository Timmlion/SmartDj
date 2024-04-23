using Microsoft.EntityFrameworkCore;
using SmartDJ.Server;

namespace SmartDj.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<SongRequest> SongRequests { get; set; }
}