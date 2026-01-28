using Resourcery.Recruitment.Localization;
using Volo.Abp.Application.Services;

namespace Resourcery.Recruitment;

public abstract class RecruitmentAppService : ApplicationService
{
    protected RecruitmentAppService()
    {
        LocalizationResource = typeof(RecruitmentResource);
        ObjectMapperContext = typeof(RecruitmentApplicationModule);
    }
}
