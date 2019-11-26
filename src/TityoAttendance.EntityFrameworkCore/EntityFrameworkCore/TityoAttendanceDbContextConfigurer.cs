using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TityoAttendance.EntityFrameworkCore
{
    public static class TityoAttendanceDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TityoAttendanceDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TityoAttendanceDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
