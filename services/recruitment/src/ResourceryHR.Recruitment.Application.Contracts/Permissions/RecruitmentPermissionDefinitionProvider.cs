using ResourceryHR.Recruitment.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ResourceryHR.Recruitment.Permissions;

public class RecruitmentPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var projectsGroup = context.AddGroup(
            RecruitmentPermissions.GroupName,
            L("Permission:Recruitment")
        );
        var projectsPermissions = projectsGroup.AddPermission(
            RecruitmentPermissions.Issues.Default,
            L("Permission:Recruitment:Issues")
        );
        projectsPermissions.AddChild(
            RecruitmentPermissions.Issues.Create,
            L("Permission:Recruitment:Issues:Create")
        );
        projectsPermissions.AddChild(
            RecruitmentPermissions.Issues.Update,
            L("Permission:Recruitment:Issues:Update")
        );
        projectsPermissions.AddChild(
            RecruitmentPermissions.Issues.Delete,
            L("Permission:Recruitment:Issues:Delete")
        );
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RecruitmentResource>(name);
    }
}
