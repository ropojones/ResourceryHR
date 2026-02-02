using System;
using Volo.Abp.Application.Dtos;

namespace ResourceryHR.Recruitment.Organizations;

public class OrganizationDto : EntityDto<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}