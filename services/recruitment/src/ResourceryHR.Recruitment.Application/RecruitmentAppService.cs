using ResourceryHR.Recruitment.Localization;
using Volo.Abp.Application.Services;

namespace ResourceryHR.Recruitment;

public abstract class RecruitmentAppService : ApplicationService
{
    protected RecruitmentAppService()
    {
        LocalizationResource = typeof(RecruitmentResource);
        ObjectMapperContext = typeof(RecruitmentApplicationModule);
    }
}
