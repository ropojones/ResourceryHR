using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace ResourceryHR.Recruitment;

[DependsOn(typeof(RecruitmentDomainModule))]
[DependsOn(typeof(RecruitmentApplicationContractsModule))]
[DependsOn(typeof(AbpDddApplicationModule))]
[DependsOn(typeof(AbpAutoMapperModule))]
public class RecruitmentApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<RecruitmentApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<RecruitmentApplicationModule>(true);
        });
    }
}
