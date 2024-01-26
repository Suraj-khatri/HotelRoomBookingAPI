using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BookingSystem.Controllers
{
    public abstract class BookingSystemControllerBase: AbpController
    {
        protected BookingSystemControllerBase()
        {
            LocalizationSourceName = BookingSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
