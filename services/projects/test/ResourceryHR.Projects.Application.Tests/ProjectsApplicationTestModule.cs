using Volo.Abp.Modularity;

namespace ResourceryHR.Projects;

[DependsOn(typeof(ProjectsApplicationModule))]
[DependsOn(typeof(ProjectsDomainTestModule))]
public class ProjectsApplicationTestModule : AbpModule { }
