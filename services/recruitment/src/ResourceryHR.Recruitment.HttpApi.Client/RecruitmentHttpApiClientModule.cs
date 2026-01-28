using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ResourceryHR.Recruitment;

[DependsOn(typeof(RecruitmentApplicationContractsModule))]
[DependsOn(typeof(AbpHttpClientModule))]
public class RecruitmentHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(RecruitmentApplicationContractsModule).Assembly,
            RecruitmentRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RecruitmentHttpApiClientModule>();
        });
    }
}
