using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TityoAttendance.Authorization.Roles;
using TityoAttendance.Authorization.Users;
using TityoAttendance.MultiTenancy;
using TityoAttendance.TityoAttendance.TityoAddress;
using TityoAttendance.TityoAttendance.TityoAttendance;
using TityoAttendance.TityoAttendance.TityoCompany;
using TityoAttendance.TityoAttendance.TityoProject;

namespace TityoAttendance.EntityFrameworkCore
{
    public class TityoAttendanceDbContext : AbpZeroDbContext<Tenant, Role, User, TityoAttendanceDbContext>
    {
        /* Define a DbSet for each entity of the application */
        // Address
        public DbSet<Country> Countries { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<NatureOfPublicPlace> NatureOfPublicPlaces { get; set; }
        public DbSet<Address> Addresses { get; set; }

        // Company
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserCompanyMap> UserCompanyMaps { get; set; }

        // Attendance
        public DbSet<Attendance> Attendances { get; set; }

        // Project
        public DbSet<Project> Projects { get; set; }

        public TityoAttendanceDbContext(DbContextOptions<TityoAttendanceDbContext> options)
            : base(options)
        {
        }
    }
}
