using System;
using DynamicQuerySample.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DynamicQuerySample.Books
{
    public class BookRepository : EfCoreRepository<DynamicQuerySampleDbContext, Book, Guid>, IBookRepository
    {
        public BookRepository(IDbContextProvider<DynamicQuerySampleDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}