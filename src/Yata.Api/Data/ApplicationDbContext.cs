using Microsoft.EntityFrameworkCore;
using Yata.Shared.Models;

namespace Yata.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Todo> Todo { get; set; }
    public virtual DbSet<Label> Label { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
            .HasMany(t => t.Labels)
            .WithMany(l => l.Todos)
            .UsingEntity(tl => tl.ToTable("TodoLabel"));

        base.OnModelCreating(modelBuilder);
    }
}
