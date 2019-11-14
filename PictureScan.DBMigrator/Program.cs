using Microsoft.EntityFrameworkCore;

namespace PictureScan.DBMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbFactory = new PSContextFactory();

            using (var db = dbFactory.CreateDbContext(null))
            {
                db.Database.Migrate();
            }
        }
    }
}
