using ResourceryHR.Projects.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ResourceryHR.Projects;

public abstract class ProjectsController : AbpControllerBase
{
    protected ProjectsController()
    {
        LocalizationResource = typeof(ProjectsResource);
    }
}
