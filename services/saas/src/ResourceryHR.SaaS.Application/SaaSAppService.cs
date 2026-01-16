using ResourceryHR.SaaS.Localization;
using Volo.Abp.Application.Services;

namespace ResourceryHR.SaaS;

public abstract class SaaSAppService : ApplicationService
{
    protected SaaSAppService()
    {
        LocalizationResource = typeof(SaaSResource);
        ObjectMapperContext = typeof(SaaSApplicationModule);
    }
}
