using BuildSharper.Course402.WebFramework.Models;
using BuildSharper.Course402.WebFramework.Services.Interfaces;
using System;

namespace BuildSharper.Course402.WebFramework.Services
{
    public class DbLogService : ILogService
    {
        public void Log(string message, Exception exception = null)
        {
            using (var db = new LogDbContext())
            {
                db.log.Add(new Log()
                {
                    Message = message,
                    DateCreated = DateTime.Now
                });

                db.SaveChanges();
            }
        }
    }
}
