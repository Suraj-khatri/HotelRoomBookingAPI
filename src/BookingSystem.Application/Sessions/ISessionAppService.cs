using System.Threading.Tasks;
using Abp.Application.Services;
using BookingSystem.Sessions.Dto;

namespace BookingSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
