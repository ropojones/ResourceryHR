using Resourcery.Recruitment.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Resourcery.Recruitment.Permissions;

public class RecruitmentPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var recruitmentGroup = context.AddGroup(
            RecruitmentPermissions.GroupName,
            L("Permission:Recruitment")
        );
        var recruitmentPermissions = recruitmentGroup.AddPermission(
            RecruitmentPermissions.Issues.Default,
            L("Permission:Recruitment:Issues")
        );
        recruitmentPermissions.AddChild(
            RecruitmentPermissions.Issues.Create,
            L("Permission:Recruitment:Issues:Create")
        );
        recruitmentPermissions.AddChild(
            RecruitmentPermissions.Issues.Update,
            L("Permission:Recruitment:Issues:Update")
        );
        recruitmentPermissions.AddChild(
            RecruitmentPermissions.Issues.Delete,
            L("Permission:Recruitment:Issues:Delete")
        );
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RecruitmentResource>(name);
    }
}
