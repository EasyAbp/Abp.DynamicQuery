using System;
using DynamicQuerySample.Books;
using DynamicQuerySample.Books.Dtos;
using Shouldly;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace DynamicQuerySample.Books
{
    public class BookMappingTests : DynamicQuerySampleApplicationTestBase
    {
        private readonly IObjectMapper _objectMapper;

        public BookMappingTests()
        {
            _objectMapper = GetRequiredService<IObjectMapper>();
        }

        [Fact]
        public void Should_Map_Book_To_BookDto()
        {
            // Arrange
            var book = new Book(
                Guid.NewGuid(),
                "The Hitchhiker's Guide to the Galaxy",
                BookType.ScienceFiction,
                new DateTime(1979, 10, 12),
                42.5f);

            // Act
            var dto = _objectMapper.Map<Book, BookDto>(book);

            // Assert
            dto.Id.ShouldBe(book.Id);
            dto.Name.ShouldBe(book.Name);
            dto.Type.ShouldBe(book.Type);
            dto.PublishDate.ShouldBe(book.PublishDate);
            dto.Price.ShouldBe(book.Price);
        }
    }
}
