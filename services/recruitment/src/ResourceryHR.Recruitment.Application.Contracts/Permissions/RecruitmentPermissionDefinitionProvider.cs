using ResourceryHR.Recruitment.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ResourceryHR.Recruitment.Permissions;

public class RecruitmentPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var recruitmentGroup = context.AddGroup(
            RecruitmentPermissions.GroupName,
            L("Permission:Recruitment")
        );
       
       //organizations permissions
        var recruitmentPermissions = recruitmentGroup.AddPermission(
            RecruitmentPermissions.Organizations.Default,
            L("Permission:Recruitment:Organizations")
        );
        recruitmentPermissions.AddChild(
            RecruitmentPermissions.Organizations.Create,
            L("Permission:Recruitment:Organizations:Create")
        );
        recruitmentPermissions.AddChild(
            RecruitmentPermissions.Organizations.Update,
            L("Permission:Recruitment:Organizations:Update")
        );
        recruitmentPermissions.AddChild(
            RecruitmentPermissions.Organizations.Delete,
            L("Permission:Recruitment:Organizations:Delete")
        );

        //Exercises permissions
        var exercisePermissions = recruitmentGroup.AddPermission(   
            RecruitmentPermissions.Exercises.Default,
            L("Permission:Recruitment:Exercises")
        );
        exercisePermissions.AddChild(
            RecruitmentPermissions.Exercises.Create,
            L("Permission:Recruitment:Exercises:Create")
        );
        exercisePermissions.AddChild(
            RecruitmentPermissions.Exercises.Update,
            L("Permission:Recruitment:Exercises:Update")
        );
        exercisePermissions.AddChild(
            RecruitmentPermissions.Exercises.Delete,
            L("Permission:Recruitment:Exercises:Delete")
        );

        //JobPostings permissions
        var jobPostingPermissions = recruitmentGroup.AddPermission(   
            RecruitmentPermissions.JobPostings.Default,
            L("Permission:Recruitment:JobPostings")
        );
        jobPostingPermissions.AddChild(
            RecruitmentPermissions.JobPostings.Create,
            L("Permission:Recruitment:JobPostings:Create")
        );
        jobPostingPermissions.AddChild(
            RecruitmentPermissions.JobPostings.Update,
            L("Permission:Recruitment:JobPostings:Update")
        );
        jobPostingPermissions.AddChild(
            RecruitmentPermissions.JobPostings.Delete,
            L("Permission:Recruitment:JobPostings:Delete")
        );  

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RecruitmentResource>(name);
    }
}
