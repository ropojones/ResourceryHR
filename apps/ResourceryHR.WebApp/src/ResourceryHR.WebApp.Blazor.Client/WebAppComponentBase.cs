using ResourceryHR.WebApp.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ResourceryHR.WebApp.Blazor.Client;

public abstract class WebAppComponentBase : AbpComponentBase
{
    protected WebAppComponentBase()
    {
        LocalizationResource = typeof(WebAppResource);
    }
}
