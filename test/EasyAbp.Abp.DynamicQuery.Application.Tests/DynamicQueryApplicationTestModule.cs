using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicQuery
{
    [DependsOn(
        typeof(DynamicQueryApplicationModule),
        typeof(DynamicQueryDomainTestModule)
        )]
    public class DynamicQueryApplicationTestModule : AbpModule
    {

    }
}
