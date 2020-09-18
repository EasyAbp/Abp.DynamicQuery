using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace DynamicQuerySample.EntityFrameworkCore
{
    public static class DynamicQuerySampleDbContextModelCreatingExtensions
    {
        public static void ConfigureDynamicQuerySample(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(DynamicQuerySampleConsts.DbTablePrefix + "YourEntities", DynamicQuerySampleConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}