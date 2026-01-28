using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Resourcery.Recruitment.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Resourcery.Recruitment;

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
    }
}
