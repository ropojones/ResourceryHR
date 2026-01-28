using ResourceryHR.Recruitment.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ResourceryHR.Recruitment;

public abstract class RecruitmentController : AbpControllerBase
{
    protected RecruitmentController()
    {
        LocalizationResource = typeof(RecruitmentResource);
    }
}
