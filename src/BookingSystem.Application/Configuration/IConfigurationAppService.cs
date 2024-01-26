using System.Threading.Tasks;
using BookingSystem.Configuration.Dto;

namespace BookingSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
