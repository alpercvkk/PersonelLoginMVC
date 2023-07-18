using Microsoft.EntityFrameworkCore;
using PersonelLoginMCVPoject.Data.Config;
using PersonelLoginMCVPoject.Data.Entities;

namespace PersonelLoginMCVPoject.Data

{
    public class PersonelListeleDbContext : DbContext
    {

        public DbSet<Personel> Personeller { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Yöntem Fluent API
            //modelBuilder.Entity<User>().HasMany<Role>();
            modelBuilder.Entity<User>().HasIndex(x => x.UserName);
            modelBuilder.Entity<User>().HasIndex(x => x.Email);
            modelBuilder.Entity<User>().Property(x => x.UserName).HasMaxLength(12); // En fazla 12 karakter olabilir .
            modelBuilder.Entity<User>().HasKey(x => x.Id); //Pk alanının belirttim.

            //modelBuilder.Entity<Role>().HasMany<User>();

            modelBuilder.ApplyConfiguration(new RoleConfig());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FAFVSUB;Database=PersonelListeleDB;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }


        
    }


}
