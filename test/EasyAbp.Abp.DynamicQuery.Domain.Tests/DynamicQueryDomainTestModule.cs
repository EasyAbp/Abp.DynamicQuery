using EasyAbp.Abp.DynamicQuery.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicQuery
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(DynamicQueryEntityFrameworkCoreTestModule)
        )]
    public class DynamicQueryDomainTestModule : AbpModule
    {
        
    }
}
