namespace ResourceryHR.SaaS;

public static class SaaSDbProperties
{
    public const string ConnectionStringName = "ResourceryHRSaaSDb";
    public static string DbTablePrefix { get; set; } = "SaaS";

    public static string DbSchema { get; set; } = null;
}
