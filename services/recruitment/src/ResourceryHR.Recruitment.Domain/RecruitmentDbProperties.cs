namespace ResourceryHR.Recruitment;

public static class RecruitmentDbProperties
{
    public const string ConnectionStringName = "ResourceryHRRecruitmentDb";
    public static string DbTablePrefix { get; set; } = "Recruitment";

    public static string DbSchema { get; set; } = null;
}
