using ResourceryHR.SaaS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ResourceryHR.SaaS;

public abstract class SaaSController : AbpControllerBase
{
    protected SaaSController()
    {
        LocalizationResource = typeof(SaaSResource);
    }
}
