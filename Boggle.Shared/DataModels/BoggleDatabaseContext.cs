using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle.Shared.DataModels
{
    public class BoggleDatabaseContext : DbContext
    {
        private static bool _created = false;
        
        public BoggleDatabaseContext()
        {
            if(!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string Path = Environment.CurrentDirectory;
            optionBuilder.UseSqlite(@"Data Source=C:\Boggle.db");
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
