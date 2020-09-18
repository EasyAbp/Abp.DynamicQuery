using System;
using System.Threading.Tasks;
using DynamicQuerySample.Books;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace DynamicQuerySample.EntityFrameworkCore.Books
{
    public class BookRepositoryTests : DynamicQuerySampleEntityFrameworkCoreTestBase
    {
        private readonly IBookRepository _bookRepository;

        public BookRepositoryTests()
        {
            _bookRepository = GetRequiredService<IBookRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
