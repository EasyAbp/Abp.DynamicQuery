using System.Threading.Tasks;

namespace DynamicQuerySample.Data
{
    public interface IDynamicQuerySampleDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
