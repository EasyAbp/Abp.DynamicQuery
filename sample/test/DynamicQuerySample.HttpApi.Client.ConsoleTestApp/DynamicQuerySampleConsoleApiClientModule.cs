using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace DynamicQuerySample.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(DynamicQuerySampleHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class DynamicQuerySampleConsoleApiClientModule : AbpModule
    {
        
    }
}
