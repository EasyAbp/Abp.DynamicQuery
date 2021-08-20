using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicQuery
{
    [DependsOn(typeof(DynamicQueryDomainModule))]
    public class DynamicQueryEntityFrameworkCoreModule : AbpModule
    {
    }
}