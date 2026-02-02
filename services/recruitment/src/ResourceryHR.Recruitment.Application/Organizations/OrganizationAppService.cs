using System;
using System.Linq;
using System.Threading.Tasks;
using ResourceryHR.Recruitment.Organizations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;
using System.Linq.Dynamic.Core;

namespace ResourceryHR.Recruitment;

public class OrganizationAppService : RecruitmentAppService, IOrganizationAppService
{
    private readonly IRepository<Organization, Guid> _organizationRepository;
    private readonly IAsyncQueryableExecuter _asyncExecuter;

    public OrganizationAppService(
        IRepository<Organization, Guid> organizationRepository,
        IAsyncQueryableExecuter asyncExecuter)
    {
        _organizationRepository = organizationRepository;
        _asyncExecuter = asyncExecuter;
    }

    public async Task<OrganizationDto> GetAsync(Guid id)
    {
        var organization = await _organizationRepository.GetAsync(id);
        return ObjectMapper.Map<Organization, OrganizationDto>(organization);
    }

    public async Task<PagedResultDto<OrganizationDto>> GetListAsync(GetOrganizationListInput input)
    {
        var queryable = await _organizationRepository.GetQueryableAsync();

        var sorting = string.IsNullOrWhiteSpace(input.Sorting) ? "Name" : input.Sorting;
        var query = queryable.OrderBy(sorting);

        var totalCount = await _asyncExecuter.CountAsync(query);
        var items = await _asyncExecuter.ToListAsync(
            query.Skip(input.SkipCount).Take(input.MaxResultCount)
        );

        var dtos = ObjectMapper.Map<
            System.Collections.Generic.List<Organization>,
            System.Collections.Generic.List<OrganizationDto>>(items);

        return new PagedResultDto<OrganizationDto>(totalCount, dtos);
    }

    public async Task<OrganizationDto> CreateAsync(CreateUpdateOrganizationDto input)
    {
        var organization = new Organization(
            GuidGenerator.Create(),
            input.Name,
            input.Description,
            CurrentTenant.Id
        );

        await _organizationRepository.InsertAsync(organization, autoSave: true);

        return ObjectMapper.Map<Organization, OrganizationDto>(organization);
    }

    public async Task<OrganizationDto> UpdateAsync(Guid id, CreateUpdateOrganizationDto input)
    {
        var organization = await _organizationRepository.GetAsync(id);

        organization.SetName(input.Name);
        organization.SetDescription(input.Description);

        await _organizationRepository.UpdateAsync(organization, autoSave: true);

        return ObjectMapper.Map<Organization, OrganizationDto>(organization);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _organizationRepository.DeleteAsync(id);
    }
}