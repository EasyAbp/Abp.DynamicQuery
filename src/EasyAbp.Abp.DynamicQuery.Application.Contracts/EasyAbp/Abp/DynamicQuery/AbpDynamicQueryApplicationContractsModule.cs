using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicQuery
{
    [DependsOn(typeof(AbpDynamicQueryDomainSharedModule))]
    public class AbpDynamicQueryApplicationContractsModule : AbpModule
    {
    }
}
