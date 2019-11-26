using Abp.Authorization;
using TityoAttendance.Authorization.Roles;
using TityoAttendance.Authorization.Users;

namespace TityoAttendance.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
