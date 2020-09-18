using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace DynamicQuerySample.EntityFrameworkCore
{
    [DependsOn(
        typeof(DynamicQuerySampleEntityFrameworkCoreModule)
        )]
    public class DynamicQuerySampleEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DynamicQuerySampleMigrationsDbContext>();
        }
    }
}
