using ResourceryHR.Administration.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ResourceryHR.Administration;

public abstract class AdministrationController : AbpControllerBase
{
    protected AdministrationController()
    {
        LocalizationResource = typeof(AdministrationResource);
    }
}
