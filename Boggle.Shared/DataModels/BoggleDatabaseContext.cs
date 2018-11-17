using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
                Database.EnsureDeleted();//this might give you some trouble...test & verify. :)
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite($@"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //we need to tell it what property has the primary key
            //this is what i did with the [Key] attribute in class...two ways to do the same thing, 
            //just whatever your preference. :)
            modelBuilder.Entity<Game>().HasKey(g => g.Id);
            modelBuilder.Entity<Player>().HasKey(p => p.Id);

            //It looks like your database is ok, we could do some testing/playing with it by adding a console project
            //should we give it a try? I am trying to use it in my WPF app could we look at that?

            //without some interface in between your BoggleDatabaseContext and your WPF project (and all the others)
            //you'll have to add EFCore as a reference to all other projects.  If you put an interface in between then 
            //the other projects just need a reference to Boggle.Shared (and that lets you swap it out later without 
            //having to change everything else in the application).

            //something like an IDataStore that exposes the operations you require (e.g. AddPlayer(), GetGames(), etc.)
            //so would the shared project contain the database?
            //It can, that's up to you - it's an architecture preference.  
            //Do you have my FlashCards demo cloned? Not yet Mayb
            //maybe I should take a look at that I think I know what I'm doing wrong and how to make it better


            //sounds good - have a fun time. :)  programming is fun (just keep telling yourself that) ;)
            //Haha thanks! g'night
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
