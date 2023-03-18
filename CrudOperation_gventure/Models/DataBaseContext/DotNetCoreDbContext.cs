using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudOperation_gventure.Models.DataBaseContext
{
    public class DotNetCoreDbContext:DbContext
    {
        public DotNetCoreDbContext()
        {
        }

        public DotNetCoreDbContext(DbContextOptions<DotNetCoreDbContext> options) : base(options) { }

        public DbSet<Companies> Companies { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=mrgupta\\sqlexpress;Initial Catalog=CrudOperation_gventure;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            //OnModelCreatingPartial(modelBuilder);
        }
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
