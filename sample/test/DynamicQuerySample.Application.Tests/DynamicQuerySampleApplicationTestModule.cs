using Volo.Abp.Modularity;

namespace DynamicQuerySample
{
    [DependsOn(
        typeof(DynamicQuerySampleApplicationModule),
        typeof(DynamicQuerySampleDomainTestModule)
        )]
    public class DynamicQuerySampleApplicationTestModule : AbpModule
    {

    }
}