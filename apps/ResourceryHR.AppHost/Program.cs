using Microsoft.Extensions.Hosting;
using Projects;
namespace ResourceryHR.AppHost;

internal class Program
{
    private static void Main(string[] args)
    {
        const string LaunchProfileName = "Aspire";
        var builder = DistributedApplication.CreateBuilder(args);

        var postgres = builder.AddPostgres(ResourceryHRNames.Postgres).WithPgWeb();
        var rabbitMq = builder.AddRabbitMQ(ResourceryHRNames.RabbitMq).WithManagementPlugin();
        var redis = builder.AddRedis(ResourceryHRNames.Redis).WithRedisCommander();
        var seq = builder.AddSeq(ResourceryHRNames.Seq);

        var adminDb = postgres.AddDatabase(ResourceryHRNames.AdministrationDb);
        var identityDb = postgres.AddDatabase(ResourceryHRNames.IdentityServiceDb);
        var projectsDb = postgres.AddDatabase(ResourceryHRNames.ProjectsDb);
        var saasDb = postgres.AddDatabase(ResourceryHRNames.SaaSDb);

        var migrator = builder
            .AddProject<ResourceryHR_DbMigrator>(
                ResourceryHRNames.DbMigrator,
                launchProfileName: LaunchProfileName
            )
            .WithReference(adminDb)
            .WithReference(identityDb)
            .WithReference(projectsDb)
            .WithReference(saasDb)
            .WithReference(seq)
            .WaitFor(postgres);

        var admin = builder
            .AddProject<ResourceryHR_Administration_HttpApi_Host>(
                ResourceryHRNames.AdministrationApi,
                launchProfileName: LaunchProfileName
            )
            .WithExternalHttpEndpoints()
            .WithReference(adminDb)
            .WithReference(identityDb)
            .WithReference(rabbitMq)
            .WithReference(redis)
            .WithReference(seq)
            .WaitForCompletion(migrator);

        var identity = builder
            .AddProject<ResourceryHR_IdentityService_HttpApi_Host>(
                ResourceryHRNames.IdentityServiceApi,
                launchProfileName: LaunchProfileName
            )
            .WithExternalHttpEndpoints()
            .WithReference(adminDb)
            .WithReference(identityDb)
            .WithReference(saasDb)
            .WithReference(rabbitMq)
            .WithReference(redis)
            .WithReference(seq)
            .WaitForCompletion(migrator);

        var saas = builder
            .AddProject<ResourceryHR_SaaS_HttpApi_Host>(
                ResourceryHRNames.SaaSApi,
                launchProfileName: LaunchProfileName
            )
            .WithExternalHttpEndpoints()
            .WithReference(adminDb)
            .WithReference(saasDb)
            .WithReference(rabbitMq)
            .WithReference(redis)
            .WithReference(seq)
            .WaitForCompletion(migrator);

        builder
            .AddProject<ResourceryHR_Projects_HttpApi_Host>(
                ResourceryHRNames.ProjectsApi,
                launchProfileName: LaunchProfileName
            )
            .WithExternalHttpEndpoints()
            .WithReference(adminDb)
            .WithReference(projectsDb)
            .WithReference(rabbitMq)
            .WithReference(redis)
            .WithReference(seq)
            .WaitForCompletion(migrator);

        var gateway = builder
            .AddProject<ResourceryHR_Gateway>(ResourceryHRNames.Gateway, launchProfileName: LaunchProfileName)
            .WithExternalHttpEndpoints()
            .WithReference(seq)
            .WaitFor(admin)
            .WaitFor(identity)
            .WaitFor(saas);

        var authserver = builder
            .AddProject<ResourceryHR_AuthServer>(
                ResourceryHRNames.AuthServer,
                launchProfileName: LaunchProfileName
            )
            .WithExternalHttpEndpoints()
            .WithReference(adminDb)
            .WithReference(identityDb)
            .WithReference(saasDb)
            .WithReference(rabbitMq)
            .WithReference(redis)
            .WithReference(seq)
            .WaitForCompletion(migrator);

        builder
            .AddProject<ResourceryHR_WebApp_Blazor>(
                ResourceryHRNames.WebAppClient,
                launchProfileName: LaunchProfileName
            )
            .WithExternalHttpEndpoints()
            .WithReference(seq)
            .WaitFor(authserver)
            .WaitFor(gateway);

        builder.Build().Run();
    }
}
