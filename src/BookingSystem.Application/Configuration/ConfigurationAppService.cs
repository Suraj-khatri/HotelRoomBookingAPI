using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BookingSystem.Configuration.Dto;

namespace BookingSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BookingSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
