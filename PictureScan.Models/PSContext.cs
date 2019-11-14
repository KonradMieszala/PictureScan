using Microsoft.EntityFrameworkCore;

namespace PictureScan.Models
{
    public class PSContext : DbContext
    {
        private const string MigrationsAssembly = "DBMigrator";
        private readonly string _connectionString;

        public DbSet<Picture> Klients { get; set; }
        public PSContext(string connectionString, int? timeout = null) : base()
        {
            _connectionString = connectionString;
            this.Database.SetCommandTimeout(timeout);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, b => b.MigrationsAssembly(MigrationsAssembly));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picture>()
                .HasIndex(e => e.Id)
                .IsUnique();

            //modelBuilder.Query<V_SHORTAGE_OF_CASH>().ToView("V_SHORTAGE_OF_CASH");
        }
    }
}
