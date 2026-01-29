using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ResourceryHR.Recruitment.Exercises;
using ResourceryHR.Recruitment.JobPostings;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ResourceryHR.Recruitment.EntityFrameworkCore;

[ConnectionStringName(ResourceryHRNames.RecruitmentDb)]
public interface IRecruitmentDbContext : IEfCoreDbContext
{
    DbSet<Exercise> Exercises { get; }
    DbSet<JobPosting> JobPostings { get; }
}
