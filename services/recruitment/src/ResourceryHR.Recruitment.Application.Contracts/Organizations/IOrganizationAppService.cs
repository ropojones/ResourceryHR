using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ResourceryHR.Recruitment.Organizations;

public interface IOrganizationAppService : IApplicationService
{
    Task<OrganizationDto> GetAsync(Guid id);

    Task<PagedResultDto<OrganizationDto>> GetListAsync(GetOrganizationListInput input);

    Task<OrganizationDto> CreateAsync(CreateUpdateOrganizationDto input);

    Task<OrganizationDto> UpdateAsync(Guid id, CreateUpdateOrganizationDto input);

    Task DeleteAsync(Guid id);
}