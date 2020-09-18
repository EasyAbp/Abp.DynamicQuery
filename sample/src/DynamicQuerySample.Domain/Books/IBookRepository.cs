using System;
using Volo.Abp.Domain.Repositories;

namespace DynamicQuerySample.Books
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
    }
}