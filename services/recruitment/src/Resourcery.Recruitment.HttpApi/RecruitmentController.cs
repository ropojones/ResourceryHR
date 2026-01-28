using Resourcery.Recruitment.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Resourcery.Recruitment;

public abstract class RecruitmentController : AbpControllerBase
{
    protected RecruitmentController()
    {
        LocalizationResource = typeof(RecruitmentResource);
    }
}
