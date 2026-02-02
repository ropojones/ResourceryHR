using AutoMapper;
using ResourceryHR.Recruitment.Organizations;

namespace ResourceryHR.Recruitment;

public class RecruitmentApplicationAutoMapperProfile : Profile
{ 
    public RecruitmentApplicationAutoMapperProfile()
    {
        CreateMap<Organization, OrganizationDto>();
        // CreateMap<CreateUpdateOrganizationDto, Organization>();
    }
}
