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
            // Get 'Hungary' id
            int countryId = _context.Countries.FirstOrDefault(c => c.Name == "Magyarország" && c.CityCode == "HU").Id;

            // Counties
            AddCountyIfNotExists("Bács-Kiskun", "BK", countryId);
            AddCountyIfNotExists("Békés", "BE", countryId);
            AddCountyIfNotExists("Baranya", "BA", countryId);
            AddCountyIfNotExists("Borsod-Abaúj-Zemplén", "BZ", countryId);
            AddCountyIfNotExists("Budapest", "BU", countryId);
            AddCountyIfNotExists("Csongrád", "CS", countryId);
            AddCountyIfNotExists("Fejér", "FE", countryId);
            AddCountyIfNotExists("Győr-Moson-Sopron", "GS", countryId);
            AddCountyIfNotExists("Hajdú-Bihar", "HB", countryId);
            AddCountyIfNotExists("Heves", "HE", countryId);
            AddCountyIfNotExists("Jász-Nagykun-Szolnok", "JN", countryId);
            AddCountyIfNotExists("Komárom-Esztergom", "KE", countryId);
            AddCountyIfNotExists("Nógrád", "NO", countryId);
            AddCountyIfNotExists("Pest", "PE", countryId);
            AddCountyIfNotExists("Somogy", "SO", countryId);
            AddCountyIfNotExists("Szabolcs-Szatmár-Bereg", "SZ", countryId);
            AddCountyIfNotExists("Tolna", "TO", countryId);
            AddCountyIfNotExists("Vas", "VA", countryId);
            AddCountyIfNotExists("Veszprém", "VE", countryId);
            AddCountyIfNotExists("Zala", "ZA", countryId);
        }

        private void AddCountyIfNotExists(string name, string countyCode, int countryId)
        {
            if (_context.Counties.IgnoreQueryFilters().Any(c => c.Name == name && c.CountryId == countryId))
            {
                return;
            }

            _context.Counties.Add(new County() { Name = name, CountyCode = countyCode, CountryId = countryId });
            _context.SaveChanges();
        }
    }
}
