using ProductLaunch.Entities;
using System.Data.Entity;

namespace ProductLaunch.Model
{
    public class ProductLaunchContext : DbContext
    {
        public static string ConnectionString { get; set; } = "name=ProductLaunchDb";

        public ProductLaunchContext() : base(ConnectionString) { }
        public ProductLaunchContext(string connectionString) : base(connectionString) { }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Prospect> Prospects { get; set; }

        public DbSet<AdminUser> AdminUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Country>().HasKey(c => c.CountryCode);
            builder.Entity<Role>().HasKey(r => r.RoleCode);
            builder.Entity<Prospect>().HasOptional<Country>(p => p.Country);
            builder.Entity<Prospect>().HasOptional<Role>(p => p.Role);            
        }        
    }
}
