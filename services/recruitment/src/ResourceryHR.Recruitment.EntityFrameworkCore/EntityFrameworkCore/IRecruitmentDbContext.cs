using Microsoft.Extensions.Hosting;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ResourceryHR.Recruitment.EntityFrameworkCore;

[ConnectionStringName(ResourceryHRNames.RecruitmentDb)]
public interface IRecruitmentDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
