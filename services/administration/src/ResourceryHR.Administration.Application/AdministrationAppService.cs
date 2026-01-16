using ResourceryHR.Administration.Localization;
using Volo.Abp.Application.Services;

namespace ResourceryHR.Administration;

public abstract class AdministrationAppService : ApplicationService
{
    protected AdministrationAppService()
    {
        LocalizationResource = typeof(AdministrationResource);
        ObjectMapperContext = typeof(AdministrationApplicationModule);
    }
}
