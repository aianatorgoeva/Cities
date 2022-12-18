using Cities.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.DAL
{
    public class GameContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=citiesapp.db");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(x => x.Name);
            builder.Entity<City>().HasKey(x => x.Name);
        }
    }
}
