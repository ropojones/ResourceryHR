using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ResourceryHR.Recruitment.Exercises;
using ResourceryHR.Recruitment.JobPostings;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ResourceryHR.Recruitment.EntityFrameworkCore;

[ConnectionStringName(ResourceryHRNames.RecruitmentDb)]
public class RecruitmentDbContext(DbContextOptions<RecruitmentDbContext> options)
    : AbpDbContext<RecruitmentDbContext>(options),
        IRecruitmentDbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<JobPosting> JobPostings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureRecruitment();
    }
}
