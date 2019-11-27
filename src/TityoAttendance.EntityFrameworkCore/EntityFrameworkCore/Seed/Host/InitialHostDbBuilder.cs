using TityoAttendance.EntityFrameworkCore.Seed.TityoAttendance;

namespace TityoAttendance.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly TityoAttendanceDbContext _context;

        public InitialHostDbBuilder(TityoAttendanceDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            // TityoAttendance
            new DefaultCountryCreator(_context).Create();
            new DefaultCountyCreator(_context).Create();
            new DefaultCityCreator(_context).Create();
            new DefaultNatureOfPublicPlaceCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
