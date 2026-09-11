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
    public DbSet<ProjectScreenshot> ProjectScreenshots => Set<ProjectScreenshot>();
    public DbSet<ProjectSkill> ProjectSkills => Set<ProjectSkill>();
    public DbSet<ExperienceSkill> ExperienceSkills => Set<ExperienceSkill>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ProjectSkill join entity
        modelBuilder.Entity<ProjectSkill>()
            .HasKey(ps => new { ps.ProjectId, ps.SkillId });

        modelBuilder.Entity<ProjectSkill>()
            .HasOne(ps => ps.Project)
            .WithMany(p => p.Skills)
            .HasForeignKey(ps => ps.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProjectSkill>()
            .HasOne(ps => ps.Skill)
            .WithMany(s => s.ProjectSkills)
            .HasForeignKey(ps => ps.SkillId)
            .OnDelete(DeleteBehavior.Cascade);

        // ExperienceSkill join entity
        modelBuilder.Entity<ExperienceSkill>()
            .HasKey(es => new { es.ExperienceId, es.SkillId });

        modelBuilder.Entity<ExperienceSkill>()
            .HasOne(es => es.Experience)
            .WithMany(e => e.Skills)
            .HasForeignKey(es => es.ExperienceId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ExperienceSkill>()
            .HasOne(es => es.Skill)
            .WithMany(s => s.ExperienceSkills)
            .HasForeignKey(es => es.SkillId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-many: Category → Skills
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Skills)
            .WithOne(s => s.Category)
            .HasForeignKey(s => s.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // One-to-many: Experience → Responsibilities
        modelBuilder.Entity<Experience>()
            .HasMany(e => e.Responsibilities)
            .WithOne(r => r.Experience)
            .HasForeignKey(r => r.ExperienceId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-many: Project → ProjectDetails
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Details)
            .WithOne(d => d.Project)
            .HasForeignKey(d => d.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-many: Project → ProjectScreenshots
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Screenshots)
            .WithOne(s => s.Project)
            .HasForeignKey(s => s.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // String length validation
        modelBuilder.Entity<Category>()
            .Property(c => c.Name).HasMaxLength(50);

        modelBuilder.Entity<Skill>()
            .Property(s => s.Name).HasMaxLength(60);

        modelBuilder.Entity<Experience>()
            .Property(e => e.Title).HasMaxLength(100);
        modelBuilder.Entity<Experience>()
            .Property(e => e.Organization).HasMaxLength(100);
        modelBuilder.Entity<Experience>()
            .Property(e => e.Location).HasMaxLength(100);

        modelBuilder.Entity<Responsibility>()
            .Property(r => r.Description).HasMaxLength(300);

        modelBuilder.Entity<Project>()
            .Property(p => p.Title).HasMaxLength(100);
        modelBuilder.Entity<Project>()
            .Property(p => p.Url).HasMaxLength(100);

        modelBuilder.Entity<ProjectDetail>()
            .Property(d => d.Description).HasMaxLength(300);

        modelBuilder.Entity<ProjectScreenshot>()
            .Property(s => s.Url).HasMaxLength(100);
        modelBuilder.Entity<ProjectScreenshot>()
            .Property(s => s.Caption).HasMaxLength(300);
    }
}