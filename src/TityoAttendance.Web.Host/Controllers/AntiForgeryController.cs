using Microsoft.AspNetCore.Antiforgery;
using TityoAttendance.Controllers;

namespace TityoAttendance.Web.Host.Controllers
{
    public class AntiForgeryController : TityoAttendanceControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
