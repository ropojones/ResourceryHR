using Volo.Abp.Modularity;

namespace ResourceryHR.SaaS;

[DependsOn(typeof(SaaSApplicationModule))]
[DependsOn(typeof(SaaSDomainTestModule))]
public class SaaSApplicationTestModule : AbpModule { }
