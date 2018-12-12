using Microsoft.EntityFrameworkCore;

namespace Boggle.Shared.DataModels
{
    public class BoggleDatabaseContext : DbContext
    {
        private static bool _created = false;
        string dbPath;
        public BoggleDatabaseContext(string dbPath)
        {
            this.dbPath = dbPath;
            if(!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite($@"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasKey(g => g.Id);
            modelBuilder.Entity<Player>().HasKey(p => p.Id);
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
