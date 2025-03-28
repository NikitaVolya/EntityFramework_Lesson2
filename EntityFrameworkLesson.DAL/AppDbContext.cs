using EntityFrameworkLesson.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkLesson.DAL
{
    public class AppDbContext : DbContext
    {

        public DbSet<FootballTeam> FootballTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionStr = connection.GetConnectionString("DefaultConnection");
            //var connectionStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ChampionBD;Integrated Security=True;Connect Timeout=30;";

            optionsBuilder.UseSqlServer(connectionStr);
        }
    }
}