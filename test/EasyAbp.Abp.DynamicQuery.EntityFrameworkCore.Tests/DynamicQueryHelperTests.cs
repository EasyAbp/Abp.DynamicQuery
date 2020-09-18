using System.Collections.Generic;
using System.Linq;
using EasyAbp.Abp.DynamicQuery.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace EasyAbp.Abp.DynamicQuery
{
    public class DynamicQueryHelperTests : DynamicQueryEntityFrameworkCoreTestBase
    {
        private readonly IDynamicQueryHelper _dynamicQueryHelper;
        private readonly IQueryable<Book> _books;

        public DynamicQueryHelperTests()
        {
            _dynamicQueryHelper = GetRequiredService<IDynamicQueryHelper>();
            _books = new[]
            {
                new Book {Name = "Book1", Price = 100f, Type = BookType.Adventure},
                new Book {Name = "Book2", Price = 200f, Type = BookType.Biography},
                new Book {Name = "Book3", Price = 300f, Type = BookType.Dystopia},
            }.AsQueryable();
        }

        [Fact]
        public void EmptyFilters()
        {
            // Arrange

            // Act
            var output1 = _dynamicQueryHelper.GetQueryByFilter(_books, null);
            var output2 = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>());

            // Assert
            output1.ShouldBeSameAs(_books);
            output2.ShouldBeSameAs(_books);
        }

        [Fact]
        public void Equal()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "Type", Operator = DynamicQueryOperator.Equal, Value = BookType.Adventure}
                })
                ;

            // Assert
            output.ShouldBe(_books.Take(1));
        }


        [Fact]
        public void NotEqual()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "Type", Operator = DynamicQueryOperator.NotEqual, Value = BookType.Adventure}
                })
                .ToList();

            // Assert
            output.ShouldBe(_books.Skip(1));
        }

        [Fact]
        public void Greater()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "Price", Operator = DynamicQueryOperator.Greater, Value = 100}
                })
                .ToList();

            // Assert
            output.ShouldBe(_books.Skip(1));
        }

        [Fact]
        public void GreaterOrEqual()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "Price", Operator = DynamicQueryOperator.GreaterOrEqual, Value = 200}
                })
                .ToList();

            // Assert
            output.ShouldBe(_books.Skip(1));
        }

        [Fact]
        public void Less()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "Price", Operator = DynamicQueryOperator.Less, Value = 300}
                })
                .ToList();

            // Assert
            output.ShouldBe(_books.Take(2));
        }

        [Fact]
        public void LessOrEqual()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "Price", Operator = DynamicQueryOperator.LessOrEqual, Value = 200}
                })
                .ToList();

            // Assert
            output.ShouldBe(_books.Take(2));
        }

        [Fact]
        public void StartWith()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "Name", Operator = DynamicQueryOperator.StartWith, Value = "Book"}
                })
                .ToList();

            // Assert
            output.ShouldBe(_books);
        }

        [Fact]
        public void NotStartWith()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "Name", Operator = DynamicQueryOperator.NotStartWith, Value = "Book1"}
                })
                .ToList();

            // Assert
            output.ShouldBe(_books.Skip(1));
        }

        [Fact]
        public void EndWith()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "Name", Operator = DynamicQueryOperator.EndWith, Value = "ok3"}
                })
                .ToList();

            // Assert
            output.ShouldBe(_books.Skip(2));
        }

        [Fact]
        public void NotEndWith()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "Name", Operator = DynamicQueryOperator.NotEndWith, Value = "ok3"}
                })
                .ToList();

            // Assert
            output.ShouldBe(_books.Take(2));
        }

        [Fact]
        public void Contain()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "Name", Operator = DynamicQueryOperator.Contain, Value = "ok"}
                })
                .ToList();

            // Assert
            output.ShouldBe(_books);
        }

        [Fact]
        public void NotContain()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.GetQueryByFilter(_books, new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "Name", Operator = DynamicQueryOperator.NotContain, Value = "ok"}
                })
                .ToList();

            // Assert
            output.ShouldBe(_books.Take(0));
        }
    }
}