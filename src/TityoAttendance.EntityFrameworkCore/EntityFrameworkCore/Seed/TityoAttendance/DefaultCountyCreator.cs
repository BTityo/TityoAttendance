using Microsoft.EntityFrameworkCore;
using System.Linq;
using TityoAttendance.TityoAttendance.TityoAddress;

namespace TityoAttendance.EntityFrameworkCore.Seed.TityoAttendance
{
    public class DefaultCountyCreator
    {
        private readonly TityoAttendanceDbContext _context;

        public DefaultCountyCreator(TityoAttendanceDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            // Counties
            AddCountyIfNotExists("Bács-Kiskun", "BK", "HU");
            AddCountyIfNotExists("Békés", "BE", "HU");
            AddCountyIfNotExists("Baranya", "BA", "HU");
            AddCountyIfNotExists("Borsod-Abaúj-Zemplén", "BZ", "HU");
            AddCountyIfNotExists("Budapest", "BU", "HU");
            AddCountyIfNotExists("Csongrád", "CS", "HU");
            AddCountyIfNotExists("Fejér", "FE", "HU");
            AddCountyIfNotExists("Győr-Moson-Sopron", "GS", "HU");
            AddCountyIfNotExists("Hajdú-Bihar", "HB", "HU");
            AddCountyIfNotExists("Heves", "HE", "HU");
            AddCountyIfNotExists("Jász-Nagykun-Szolnok", "JN", "HU");
            AddCountyIfNotExists("Komárom-Esztergom", "KE", "HU");
            AddCountyIfNotExists("Nógrád", "NO", "HU");
            AddCountyIfNotExists("Pest", "PE", "HU");
            AddCountyIfNotExists("Somogy", "SO", "HU");
            AddCountyIfNotExists("Szabolcs-Szatmár-Bereg", "SZ", "HU");
            AddCountyIfNotExists("Tolna", "TO", "HU");
            AddCountyIfNotExists("Vas", "VA", "HU");
            AddCountyIfNotExists("Veszprém", "VE", "HU");
            AddCountyIfNotExists("Zala", "ZA", "HU");
        }

        private void AddCountyIfNotExists(string name, string countyCode, string countryCode)
        {
            if (_context.Counties.IgnoreQueryFilters().Any(c => c.Name == name && c.CountyCode == countyCode && c.CountryCode == countryCode))
            {
                return;
            }

            _context.Counties.Add(new County() { Name = name, CountyCode = countyCode, CountryCode = countryCode });
            _context.SaveChanges();
        }
    }
}
