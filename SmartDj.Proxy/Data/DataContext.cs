using Microsoft.EntityFrameworkCore;
using SmartDj.Proxy.Models;

namespace SmartDj.Server.Proxy;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> SongRequests { get; set; }
}