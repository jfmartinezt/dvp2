using CL.Server.Middleware.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CL.Server.Middleware.Model.Context
{
  public class PSDBContext : DbContext
  {
    private readonly string dbConnectionString;
    public PSDBContext(string dbConnectionString)
    {
      this.dbConnectionString = dbConnectionString;
    }

    public PSDBContext(DbContextOptions<PSDBContext> options) : base(options) { }
    public DbSet<person> person { get; set; }
    public DbSet<user> user { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<person>(entity =>
      {
        entity.HasKey("person_id");
        entity.Property("name_full")
              .HasComputedColumnSql("CONCAT([name], ' ', [surname])");
        entity.Property("document_full")
              .HasComputedColumnSql("CONCAT([document_type], ' ', [document_number])");
      });

      modelBuilder.Entity<user>(entity =>
      {
        entity.HasKey("user_id");
      });
    }
  }
}
