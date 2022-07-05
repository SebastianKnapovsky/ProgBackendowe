using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext 
    {
        //oltis
        //private string _connectionString = "Data Source=SKNAP;User ID=wp_user;Password=corridor;Initial Catalog=RestaurantDb;MultipleActiveResultSets=true";
        //
        //mojlap
        private string _connectionString = "Server=(localdb)\\localhost;Database=RestaurantDb;MultipleActiveResultSets=true";
        //
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();
            modelBuilder.Entity<Address>()
               .Property(a => a.City)
               .IsRequired()
               .HasMaxLength(50);
            modelBuilder.Entity<Address>()
               .Property(a => a.Street)
               .IsRequired()
               .HasMaxLength(50);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
