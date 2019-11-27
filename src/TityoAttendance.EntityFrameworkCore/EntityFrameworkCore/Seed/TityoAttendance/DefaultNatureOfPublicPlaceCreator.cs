using Microsoft.EntityFrameworkCore;
using System.Linq;
using TityoAttendance.TityoAttendance.TityoAddress;

namespace TityoAttendance.EntityFrameworkCore.Seed.TityoAttendance
{
    public class DefaultNatureOfPublicPlaceCreator
    {
        private readonly TityoAttendanceDbContext _context;

        public DefaultNatureOfPublicPlaceCreator(TityoAttendanceDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            // Counties
            AddNatureOfPublicPlaceIfNotExists("utca");
            AddNatureOfPublicPlaceIfNotExists("sor");
            AddNatureOfPublicPlaceIfNotExists("tér");
            AddNatureOfPublicPlaceIfNotExists("dűlőút");
            AddNatureOfPublicPlaceIfNotExists("lépcső");
            AddNatureOfPublicPlaceIfNotExists("köz");
            AddNatureOfPublicPlaceIfNotExists("park");
            AddNatureOfPublicPlaceIfNotExists("út");
            AddNatureOfPublicPlaceIfNotExists("sétány");
            AddNatureOfPublicPlaceIfNotExists("dűlő");
            AddNatureOfPublicPlaceIfNotExists("körút");
            AddNatureOfPublicPlaceIfNotExists("útja");
            AddNatureOfPublicPlaceIfNotExists("udvar");
            AddNatureOfPublicPlaceIfNotExists("tere");
            AddNatureOfPublicPlaceIfNotExists("erdősor");
            AddNatureOfPublicPlaceIfNotExists("határút");
            AddNatureOfPublicPlaceIfNotExists("part");
            AddNatureOfPublicPlaceIfNotExists("bástya");
            AddNatureOfPublicPlaceIfNotExists("lejtő");
            AddNatureOfPublicPlaceIfNotExists("rakpart");
            AddNatureOfPublicPlaceIfNotExists("átjáró");
            AddNatureOfPublicPlaceIfNotExists("árok");
            AddNatureOfPublicPlaceIfNotExists("lejáró");
            AddNatureOfPublicPlaceIfNotExists("parkja");
            AddNatureOfPublicPlaceIfNotExists("kert");
            AddNatureOfPublicPlaceIfNotExists("körönd");
            AddNatureOfPublicPlaceIfNotExists("kapu");
            AddNatureOfPublicPlaceIfNotExists("határsor");
            AddNatureOfPublicPlaceIfNotExists("fasora");
            AddNatureOfPublicPlaceIfNotExists("fasor");
            AddNatureOfPublicPlaceIfNotExists("sétaút");
            AddNatureOfPublicPlaceIfNotExists("gát");
            AddNatureOfPublicPlaceIfNotExists("üdülőpart");
            AddNatureOfPublicPlaceIfNotExists("bástyája");
            AddNatureOfPublicPlaceIfNotExists("körútja");
            AddNatureOfPublicPlaceIfNotExists("sziget");
            AddNatureOfPublicPlaceIfNotExists("telep");
            AddNatureOfPublicPlaceIfNotExists("liget");
            AddNatureOfPublicPlaceIfNotExists("körtér");
            AddNatureOfPublicPlaceIfNotExists("forduló");
            AddNatureOfPublicPlaceIfNotExists("sugárút");
            AddNatureOfPublicPlaceIfNotExists("mélyút");
        }

        private void AddNatureOfPublicPlaceIfNotExists(string name)
        {
            if (_context.NatureOfPublicPlaces.IgnoreQueryFilters().Any(c => c.Name == name))
            {
                return;
            }

            _context.NatureOfPublicPlaces.Add(new NatureOfPublicPlace() { Name = name });
            _context.SaveChanges();
        }
    }
}
