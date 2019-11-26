using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TityoAttendance.Configuration;
using TityoAttendance.Web;

namespace TityoAttendance.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TityoAttendanceDbContextFactory : IDesignTimeDbContextFactory<TityoAttendanceDbContext>
    {
        public TityoAttendanceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TityoAttendanceDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TityoAttendanceDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TityoAttendanceConsts.ConnectionStringName));

            return new TityoAttendanceDbContext(builder.Options);
        }
    }
}
