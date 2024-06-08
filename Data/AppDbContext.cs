using Microsoft.EntityFrameworkCore;
using Notes.Entities;

namespace Notes.Data;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Note> Notes => Set<Note>();

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
    }
}