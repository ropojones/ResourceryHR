using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace ResourceryHR.Recruitment.Organizations;

[Area(RecruitmentRemoteServiceConsts.ModuleName)]
[RemoteService(Name = RecruitmentRemoteServiceConsts.RemoteServiceName)]
[Route("api/recruitment/organizations")]
public class OrganizationController : RecruitmentController, IOrganizationAppService
{
    private readonly IOrganizationAppService _organizationAppService;

    public OrganizationController(IOrganizationAppService organizationAppService)
    {
        _organizationAppService = organizationAppService;
    }

    [HttpGet]
    [Route("{id}")]
    public Task<OrganizationDto> GetAsync(Guid id)
    {
        return _organizationAppService.GetAsync(id);
    }

    [HttpGet]
    public Task<PagedResultDto<OrganizationDto>> GetListAsync(GetOrganizationListInput input)
    {
        return _organizationAppService.GetListAsync(input);
    }

    [HttpPost]
    public Task<OrganizationDto> CreateAsync(CreateUpdateOrganizationDto input)
    {
        return _organizationAppService.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public Task<OrganizationDto> UpdateAsync(Guid id, CreateUpdateOrganizationDto input)
    {
        return _organizationAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task DeleteAsync(Guid id)
    {
        return _organizationAppService.DeleteAsync(id);
    }
}