using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DynamicQuerySample.Data
{
    /* This is used if database provider does't define
     * IDynamicQuerySampleDbSchemaMigrator implementation.
     */
    public class NullDynamicQuerySampleDbSchemaMigrator : IDynamicQuerySampleDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}