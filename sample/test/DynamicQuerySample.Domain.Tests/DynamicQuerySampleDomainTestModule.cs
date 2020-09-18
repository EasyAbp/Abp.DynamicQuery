using DynamicQuerySample.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DynamicQuerySample
{
    [DependsOn(
        typeof(DynamicQuerySampleEntityFrameworkCoreTestModule)
        )]
    public class DynamicQuerySampleDomainTestModule : AbpModule
    {

    }
}