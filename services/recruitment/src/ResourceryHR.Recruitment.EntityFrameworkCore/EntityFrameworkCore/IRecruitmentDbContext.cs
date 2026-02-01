using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ResourceryHR.Recruitment.Exercises;
using ResourceryHR.Recruitment.JobPostings;
using ResourceryHR.Recruitment.Organizations;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ResourceryHR.Recruitment.EntityFrameworkCore;

[ConnectionStringName(ResourceryHRNames.RecruitmentDb)]
public interface IRecruitmentDbContext : IEfCoreDbContext
{
    DbSet<Exercise> Exercises { get; }
    DbSet<Organization> Organizations { get; }
    DbSet<JobPosting> JobPostings { get; }
}
