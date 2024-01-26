using Abp.Authorization;
using BookingSystem.Authorization.Roles;
using BookingSystem.Authorization.Users;

namespace BookingSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
