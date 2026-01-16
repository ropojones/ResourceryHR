using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Hosting;

public static class HostApplicationBuilderExtensions
{
    public static IHostApplicationBuilder AddSharedEndpoints(this IHostApplicationBuilder builder)
    {
        builder.AddRabbitMQClient(
            connectionName: ResourceryHRNames.RabbitMq,
            action =>
                action.ConnectionString = builder.Configuration.GetConnectionString(
                    ResourceryHRNames.RabbitMq
                )
        );
        builder.AddRedisDistributedCache(connectionName: ResourceryHRNames.Redis);
        builder.AddSeqEndpoint(connectionName: ResourceryHRNames.Seq);

        return builder;
    }
}
