using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DynamicQuerySample.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class DynamicQuerySampleDbContextFactory : IDesignTimeDbContextFactory<DynamicQuerySampleDbContext>
    {
        public DynamicQuerySampleDbContext CreateDbContext(string[] args)
        {
            DynamicQuerySampleEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<DynamicQuerySampleDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new DynamicQuerySampleDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DynamicQuerySample.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
