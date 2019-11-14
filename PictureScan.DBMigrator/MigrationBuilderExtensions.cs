using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
using System.Reflection;

namespace PictureScan.DBMigrator
{
    public static class MigrationBuilderExtensions
    {
        public static void SqlFromResource(this MigrationBuilder builder, string resourceName)
        {
            string sql = string.Empty;

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    sql = reader.ReadToEnd();
                }
            }

            builder.Sql(sql);
        }
    }
}
