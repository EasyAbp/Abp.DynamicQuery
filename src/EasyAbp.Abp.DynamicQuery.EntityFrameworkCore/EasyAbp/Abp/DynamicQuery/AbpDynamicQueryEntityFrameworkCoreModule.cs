using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicQuery
{
    [DependsOn(typeof(AbpDynamicQueryDomainModule))]
    public class AbpDynamicQueryEntityFrameworkCoreModule : AbpModule
    {
    }
}