using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Mapperly;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace EasyAbp.Abp.DynamicQuery
{
    [DependsOn(
        typeof(AbpDynamicQueryDomainModule),
        typeof(AbpDynamicQueryApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpMapperlyModule)
        )]
    public class AbpDynamicQueryApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMapperlyObjectMapper<AbpDynamicQueryApplicationModule>();
        }
    }
}
