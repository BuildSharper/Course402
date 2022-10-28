using BuildSharper.Course402.WebCore.Models;
using BuildSharper.Course402.WebCore.Services.Interfaces;

namespace BuildSharper.Course402.WebCore.Services
{
    public class DbLogService : ILogService
    {
        public void Log(string message, Exception? exception = null)
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
