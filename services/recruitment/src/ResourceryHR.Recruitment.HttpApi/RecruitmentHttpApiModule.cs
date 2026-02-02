using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using ResourceryHR.Recruitment.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace ResourceryHR.Recruitment;

[DependsOn(typeof(RecruitmentApplicationContractsModule))]
[DependsOn(typeof(AbpAspNetCoreMvcModule))]
public class RecruitmentHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(RecruitmentHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources.Get<RecruitmentResource>().AddBaseTypes(typeof(AbpUiResource));
        });
          
        // Configure<AbpAspNetCoreMvcOptions>(options =>
        // {
        //     options.ConventionalControllers.Create(typeof(RecruitmentApplicationModule).Assembly);
        // });
    }
}
