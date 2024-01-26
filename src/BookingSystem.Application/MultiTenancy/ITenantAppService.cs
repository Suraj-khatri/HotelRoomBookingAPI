using Abp.Application.Services;
using BookingSystem.MultiTenancy.Dto;

namespace BookingSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

