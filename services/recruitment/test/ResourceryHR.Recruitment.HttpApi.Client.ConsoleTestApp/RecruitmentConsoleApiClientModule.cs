using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ResourceryHR.Recruitment.HttpApi.Client.ConsoleTestApp;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(RecruitmentHttpApiClientModule))]
[DependsOn(typeof(AbpHttpClientIdentityModelModule))]
public class RecruitmentConsoleApiClientModule : AbpModule { }
