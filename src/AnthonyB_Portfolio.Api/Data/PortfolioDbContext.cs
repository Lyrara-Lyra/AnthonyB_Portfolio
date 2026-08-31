using AnthonyB_Portfolio.Core.Entities; 
using Microsoft.EntityFrameworkCore;

namespace AnthonyB_Portfolio.Api.Data;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
        : base(options) { }

    // Each DbSet represents a table in the database
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Experience> Experiences => Set<Experience>();
    public DbSet<Responsibility> Responsibilities => Set<Responsibility>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectDetail> ProjectDetails => Set<ProjectDetail>();

    // This is where we configure how our C# classes map to database tables
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Many-to-many: Skill ↔ Project
        modelBuilder.Entity<Skill>()
            .HasMany(s => s.Projects)
            .WithMany(p => p.Skills)
            .UsingEntity<Dictionary<string, object>>(
                // Name of the join table
                "ProjectSkills",                
                j => j.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
                j => j.HasOne<Skill>().WithMany().HasForeignKey("SkillId")
            );

        // Many-to-many: Skill ↔ Experience
        modelBuilder.Entity<Skill>()
            .HasMany(s => s.Experiences)
            .WithMany(e => e.Skills)
            .UsingEntity<Dictionary<string, object>>(
                "ExperienceSkills",
                j => j.HasOne<Experience>().WithMany().HasForeignKey("ExperienceId"),
                j => j.HasOne<Skill>().WithMany().HasForeignKey("SkillId"));

        // One-to-many: Category → Skills (Restrict cascade delete)
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Skills)
            .WithOne(s => s.Category)
            .HasForeignKey(s => s.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // One-to-many: Experience → Responsibilities (Cascade delete)
        modelBuilder.Entity<Experience>()
            .HasMany(e => e.Responsibilities)
            .WithOne(r => r.Experience)
            .HasForeignKey(r => r.ExperienceId)
            .OnDelete(DeleteBehavior.Cascade);  // Delete responsibilities with experience

        // One-to-many: Project → ProjectDetails
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Details)
            .WithOne(d => d.Project)
            .HasForeignKey(d => d.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // String length validation
        modelBuilder.Entity<Category>()
            .Property(c => c.Name).HasMaxLength(50);

        modelBuilder.Entity<Skill>()
            .Property(s => s.Name).HasMaxLength(60);

        modelBuilder.Entity<Experience>()
            .Property(e => e.Title).HasMaxLength(120);
        modelBuilder.Entity<Experience>()
            .Property(e => e.Organization).HasMaxLength(120);
        modelBuilder.Entity<Experience>()
            .Property(e => e.Location).HasMaxLength(120);

        modelBuilder.Entity<Responsibility>()
            .Property(r => r.Description).HasMaxLength(300);

        modelBuilder.Entity<Project>()
            .Property(p => p.Title).HasMaxLength(120);
        modelBuilder.Entity<Project>()
            .Property(p => p.Url).HasMaxLength(500);

        modelBuilder.Entity<ProjectDetail>()
            .Property(d => d.Description).HasMaxLength(300);
    }
}