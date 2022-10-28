using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;

namespace BuildSharper.Course402.WebFramework.Models
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
        public LogDbContext()
            : base("BuildSharperConnectionString")
        {

        }

        public DbSet<Log> log { get; set; }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<LogDbContext>(null);
            base.OnModelCreating(dbModelBuilder);
        }
    }
}