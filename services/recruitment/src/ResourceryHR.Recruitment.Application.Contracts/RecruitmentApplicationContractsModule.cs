using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace ResourceryHR.Recruitment;

[DependsOn(typeof(RecruitmentDomainSharedModule))]
[DependsOn(typeof(AbpDddApplicationContractsModule))]
[DependsOn(typeof(AbpAuthorizationModule))]
public class RecruitmentApplicationContractsModule : AbpModule { }
