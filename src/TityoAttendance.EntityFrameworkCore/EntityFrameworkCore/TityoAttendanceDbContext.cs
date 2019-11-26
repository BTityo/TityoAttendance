using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TityoAttendance.Authorization.Roles;
using TityoAttendance.Authorization.Users;
using TityoAttendance.MultiTenancy;

namespace TityoAttendance.EntityFrameworkCore
{
    public class TityoAttendanceDbContext : AbpZeroDbContext<Tenant, Role, User, TityoAttendanceDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TityoAttendanceDbContext(DbContextOptions<TityoAttendanceDbContext> options)
            : base(options)
        {
        }
    }
}
