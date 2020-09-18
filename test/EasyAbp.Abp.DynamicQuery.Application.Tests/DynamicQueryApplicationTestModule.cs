using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicQuery
{
    [DependsOn(
        typeof(DynamicQueryApplicationContractsModule),
        typeof(DynamicQueryDomainTestModule)
        )]
    public class DynamicQueryApplicationTestModule : AbpModule
    {

    }
}
