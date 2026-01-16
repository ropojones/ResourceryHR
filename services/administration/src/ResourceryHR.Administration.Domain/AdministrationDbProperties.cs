namespace ResourceryHR.Administration;

public static class AdministrationDbProperties
{
    public const string ConnectionStringName = "ResourceryHRAdministrationDb";
    public static string DbTablePrefix { get; set; } = "Administration";

    public static string DbSchema { get; set; } = null;
}
