using Microsoft.EntityFrameworkCore;
using Yata.Shared.Models;

namespace Yata.Api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
            .HasMany(t => t.Labels)
            .WithMany(l => l.Todos)
            .UsingEntity(tl => tl.ToTable("TodoLabels"));

        base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<Todo> Todos { get; set; }
    public virtual DbSet<Label> Labels { get; set; }
}
