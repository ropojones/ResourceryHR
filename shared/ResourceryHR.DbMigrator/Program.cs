using Serilog;
using ResourceryHR.Administration.EntityFrameworkCore;
using ResourceryHR.Projects.EntityFrameworkCore;
using ResourceryHR.SaaS.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace ResourceryHR.DbMigrator;

internal class Program
{
    private static async Task Main(string[] args)
    {
        ResourceryHRLogging.Initialize();

        var builder = Host.CreateApplicationBuilder(args);

        builder.AddServiceDefaults();

        builder.AddNpgsqlDbContext<AdministrationDbContext>(
            connectionName: ResourceryHRNames.AdministrationDb
        );
        builder.AddNpgsqlDbContext<IdentityDbContext>(connectionName: ResourceryHRNames.IdentityServiceDb);
        builder.AddNpgsqlDbContext<SaaSDbContext>(connectionName: ResourceryHRNames.SaaSDb);
        builder.AddNpgsqlDbContext<ProjectsDbContext>(connectionName: ResourceryHRNames.ProjectsDb);

        builder.Configuration.AddAppSettingsSecretsJson();

        builder.Logging.AddSerilog();

        builder.Services.AddHostedService<DbMigratorHostedService>();

        var host = builder.Build();

        await host.RunAsync();
    }
}
