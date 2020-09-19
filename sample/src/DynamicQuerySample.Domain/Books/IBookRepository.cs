using System;
using System.Linq;
using EasyAbp.Abp.DynamicQuery.Filters;
using Volo.Abp.Domain.Repositories;

namespace DynamicQuerySample.Books
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
        IQueryable<Book> ExecuteDynamicQuery(DynamicQueryGroup group);
    }
}