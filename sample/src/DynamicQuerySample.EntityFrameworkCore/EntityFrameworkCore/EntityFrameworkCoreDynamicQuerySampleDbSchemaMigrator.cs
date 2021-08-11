using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DynamicQuerySample.Data;
using Volo.Abp.DependencyInjection;

namespace DynamicQuerySample.EntityFrameworkCore
{
    public class EntityFrameworkCoreDynamicQuerySampleDbSchemaMigrator
        : IDynamicQuerySampleDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreDynamicQuerySampleDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the DynamicQuerySampleDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<DynamicQuerySampleDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
