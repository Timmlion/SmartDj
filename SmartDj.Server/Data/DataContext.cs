using Microsoft.EntityFrameworkCore;
using SmartDj.Shared.Models;

namespace SmartDj.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<SongRequest> SongRequests { get; set; }
    public DbSet<FormTemplate> FormTemplates { get; set; }
}