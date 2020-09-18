using DynamicQuerySample.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

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


            builder.Entity<Book>(b =>
            {
                b.ToTable(DynamicQuerySampleConsts.DbTablePrefix + "Books", DynamicQuerySampleConsts.DbSchema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });
        }
    }
}
