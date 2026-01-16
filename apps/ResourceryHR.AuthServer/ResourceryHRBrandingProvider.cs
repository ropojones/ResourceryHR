using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ResourceryHR;

[Dependency(ReplaceServices = true)]
public class ResourceryHRBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ResourceryHR";
}
