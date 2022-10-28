using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BuildSharper.Course402.WebCore.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class LogDbContext : DbContext
    {
        public DbSet<Log> log { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("BuildSharperConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
