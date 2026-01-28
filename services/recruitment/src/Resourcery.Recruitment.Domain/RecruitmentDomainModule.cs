using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Resourcery.Recruitment;

[DependsOn(typeof(AbpDddDomainModule))]
[DependsOn(typeof(RecruitmentDomainSharedModule))]
public class RecruitmentDomainModule : AbpModule { }
