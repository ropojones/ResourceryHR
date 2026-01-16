namespace ResourceryHR.Projects;

public static class ProjectsDbProperties
{
    public const string ConnectionStringName = "ResourceryHRProjectsDb";
    public static string DbTablePrefix { get; set; } = "Projects";

    public static string DbSchema { get; set; } = null;
}
