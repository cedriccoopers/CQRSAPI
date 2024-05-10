using CQRS.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace CQRS.DataService.Data
{
    public class AppDbContext : DbContext
    {
        //Define the db entities
        public virtual DbSet<Driver> Drivers { get; set; }  
        public virtual DbSet<Achievement> Achievements { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Specified the relationship between the entities
            modelBuilder.Entity<Achievement>(entity =>
                {
                    entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Achievements)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Achievements_Driver");
                }
            );
        }
    }
}
