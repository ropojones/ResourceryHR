using Volo.Abp.Reflection;

namespace ResourceryHR.Recruitment.Permissions;

public class RecruitmentPermissions
{
    public const string GroupName = "Recruitment";

    public static class Organizations
    {
        public const string Default = GroupName + ".Organizations";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class Exercises
    {
        public const string Default = GroupName + ".Exercises";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class JobPostings
    {
        public const string Default = GroupName + ".JobPostings";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }


    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(RecruitmentPermissions));
    }
}
