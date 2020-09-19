using System;
using System.Linq;
using DynamicQuerySample.EntityFrameworkCore;
using EasyAbp.Abp.DynamicQuery;
using EasyAbp.Abp.DynamicQuery.Filters;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DynamicQuerySample.Books
{
    public class BookRepository : EfCoreRepository<DynamicQuerySampleDbContext, Book, Guid>, IBookRepository
    {
        private readonly IDynamicQueryHelper _dynamicQueryHelper;
        public BookRepository(IDbContextProvider<DynamicQuerySampleDbContext> dbContextProvider, IDynamicQueryHelper dynamicQueryHelper) : base(dbContextProvider)
        {
            _dynamicQueryHelper = dynamicQueryHelper;
        }

        public IQueryable<Book> ExecuteDynamicQuery(DynamicQueryGroup group)
        {
            return _dynamicQueryHelper.ExecuteDynamicQuery(DbSet.AsQueryable(), group);
        }
    }
}