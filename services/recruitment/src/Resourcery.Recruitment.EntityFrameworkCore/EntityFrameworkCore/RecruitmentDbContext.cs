using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Resourcery.Recruitment.EntityFrameworkCore;

[ConnectionStringName(ResourceryNames.RecruitmentDb)]
public class RecruitmentDbContext(DbContextOptions<RecruitmentDbContext> options)
    : AbpDbContext<RecruitmentDbContext>(options),
        IRecruitmentDbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureRecruitment();
    }
}
