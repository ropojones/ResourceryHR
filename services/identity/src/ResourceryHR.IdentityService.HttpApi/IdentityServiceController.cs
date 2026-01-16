using ResourceryHR.IdentityService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ResourceryHR.IdentityService;

public abstract class IdentityServiceController : AbpControllerBase
{
    protected IdentityServiceController()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}
