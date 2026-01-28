using Volo.Abp.Modularity;

namespace ResourceryHR.Recruitment;

[DependsOn(typeof(RecruitmentApplicationModule))]
[DependsOn(typeof(RecruitmentDomainTestModule))]
public class RecruitmentApplicationTestModule : AbpModule { }
