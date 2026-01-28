using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace ResourceryHR.Recruitment.EntityFrameworkCore;

[DependsOn(typeof(RecruitmentTestBaseModule))]
[DependsOn(typeof(RecruitmentEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpEntityFrameworkCoreSqliteModule))]
public class RecruitmentEntityFrameworkCoreTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var sqliteConnection = CreateDatabaseAndGetConnection();

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(abpDbContextConfigurationContext =>
            {
                abpDbContextConfigurationContext.DbContextOptions.UseSqlite(sqliteConnection);
            });
        });

        context.Services.AddAlwaysDisableUnitOfWorkTransaction();
    }

    private static SqliteConnection CreateDatabaseAndGetConnection()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        new RecruitmentDbContext(
            new DbContextOptionsBuilder<RecruitmentDbContext>().UseSqlite(connection).Options
        )
            .GetService<IRelationalDatabaseCreator>()
            .CreateTables();

        return connection;
    }
}
