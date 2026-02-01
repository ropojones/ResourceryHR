using System;
using System.Threading.Tasks;
using ResourceryHR.Recruitment.Organizations;
using System.Linq;
// ...existing code...
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace ResourceryHR.Recruitment;

public class RecruitmentOrganizationDataSeedContributor(
    ICurrentTenant currentTenant,
    IRepository<Organization, Guid> organizationRepository
) : IDataSeedContributor, ITransientDependency
{
    private readonly ICurrentTenant _currentTenant = currentTenant;
    private readonly IRepository<Organization, Guid> _organizationRepository = organizationRepository;

    public async Task SeedAsync(DataSeedContext context)
    {
        using (_currentTenant.Change(context?.TenantId))
        {
            var organizations = new[]
            {
                "ECOWAS Commission",
                "ECOWAS Parliament",
                "Community Court of Justice",
                "ECOWAS Bank for Investment and Development (EBID)",
                "West African Health Organisation (WAHO)",
                "The Inter-Governmental Action Group against Money Laundering and Terrorism Financing in West Africa (GIABA)",
                "Office of the Auditor General",
                "Reg. Center for Surveillance & Disease Control(RCSDC)",
                "The West African Power Pool (WAPP)",
                "ECOWAS Regional Competition Authority(ERCA)",
                "Regional Animal Health Centre (RAHC)",
                "Water Resources Coordination Centre",
                "West African Monetary Agency (WAMA)",
                "West African Monetary Institute (WAMI)",
                "ECOWAS Youth & Sports Dev. Centre (EYSDC)",
                "ECOWAS Gender Development Centre (EGDC)",
                "ECOWAS Brown Card",
                "ECOWAS Center for Renewable Energy and Energy Efficiency (ECREEE)",
                "ECOWAS Regional Electricity Regulatory Authority (ERERA)",
                "Regional Agency for Agriculture and Food (RAAF)",
                "Project Preparation and Dev. Unit (PPDU)"
            };

            var existingNames = (await _organizationRepository.GetListAsync())
                      .Select(o => o.Name)
                      .ToHashSet(StringComparer.OrdinalIgnoreCase);

            foreach (var name in organizations)
            {
                if (existingNames.Contains(name))
                {
                    continue;
                }

                await _organizationRepository.InsertAsync(new Organization(Guid.NewGuid(), name));
            }
        }
    }
}