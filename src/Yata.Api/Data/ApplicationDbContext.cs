using Microsoft.EntityFrameworkCore;
using Yata.Shared.Models;

namespace Yata.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public virtual DbSet<Todo> Todos { get; set; }
    public virtual DbSet<Label> Labels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
