using Microsoft.EntityFrameworkCore;

namespace AngularWithAsp.Server.Models
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<LPU> Lpus { get; set; }
    public DbSet<KS> Ks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<LPU>()
          .ToTable("lpu_nsi", schema: "dbo");

      modelBuilder.Entity<KS>()
          .ToTable("ks_nsi", schema: "dbo");

      modelBuilder.Entity<LPU>()
          .HasKey(l => l.kodlpu);

      modelBuilder.Entity<KS>()
          .HasKey(k => k.kodks);

      modelBuilder.Entity<KS>()
          .HasOne(k => k.LPU)
          .WithMany(l => l.KSList)
          .HasForeignKey(k => k.kodlpu)
          .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
