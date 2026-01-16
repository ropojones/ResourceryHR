namespace ResourceryHR.IdentityService;

public static class IdentityServiceDbProperties
{
    public const string ConnectionStringName = "ResourceryHRIdentityServiceDb";
    public static string DbTablePrefix { get; set; } = "IdentityService";

    public static string DbSchema { get; set; } = null;
}
