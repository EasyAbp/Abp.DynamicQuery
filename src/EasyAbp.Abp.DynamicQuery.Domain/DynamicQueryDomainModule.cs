using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicQuery
{
    [DependsOn(typeof(DynamicQueryDomainSharedModule))]
    public class DynamicQueryDomainModule : AbpModule
    {
    }
}