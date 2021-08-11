using DynamicQuerySample.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace DynamicQuerySample.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(DynamicQuerySampleEntityFrameworkCoreModule),
        typeof(DynamicQuerySampleApplicationContractsModule)
        )]
    public class DynamicQuerySampleDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
