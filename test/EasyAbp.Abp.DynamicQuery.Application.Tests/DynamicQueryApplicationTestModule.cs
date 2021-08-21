using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicQuery
{
    [DependsOn(
        typeof(AbpDynamicQueryApplicationModule),
        typeof(DynamicQueryDomainTestModule)
        )]
    public class DynamicQueryApplicationTestModule : AbpModule
    {

    }
}
