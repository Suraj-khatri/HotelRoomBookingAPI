using System.Threading.Tasks;
using Abp.Application.Services;
using BookingSystem.Authorization.Accounts.Dto;

namespace BookingSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
