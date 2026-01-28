using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace ResourceryHR.Recruitment.Samples;

[Area(RecruitmentRemoteServiceConsts.ModuleName)]
[RemoteService(Name = RecruitmentRemoteServiceConsts.RemoteServiceName)]
[Route("api/Recruitment/sample")]
public class SampleController(ISampleAppService sampleAppService)
    : RecruitmentController,
        ISampleAppService
{
    private readonly ISampleAppService _sampleAppService = sampleAppService;

    [HttpGet]
    public async Task<SampleDto> GetAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet]
    [Route("authorized")]
    [Authorize]
    public async Task<SampleDto> GetAuthorizedAsync()
    {
        return await _sampleAppService.GetAsync();
    }
}
