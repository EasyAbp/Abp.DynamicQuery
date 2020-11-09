using System.Collections.Generic;
using System.Linq;
using EasyAbp.Abp.DynamicQuery.EntityFrameworkCore;
using EasyAbp.Abp.DynamicQuery.Filters;
using Shouldly;
using Xunit;

namespace EasyAbp.Abp.DynamicQuery
{
    public class DynamicQueryHelperGroupTests : DynamicQueryEntityFrameworkCoreTestBase
    {
        private readonly IDynamicQueryHelper _dynamicQueryHelper;
        private readonly IQueryable<Book> _books;

        public DynamicQueryHelperGroupTests()
        {
            _dynamicQueryHelper = GetRequiredService<IDynamicQueryHelper>();
            _books = new[]
            {
                new Book {Name = "Book1", Price = 100f, Type = BookType.Adventure},
                new Book {Name = "Book2", Price = 200f, Type = BookType.Biography},
                new Book {Name = "Book3", Price = 300f, Type = BookType.Dystopia},
                new Book {Name = "Book4", Price = 400f, Type = BookType.Adventure},
            }.AsQueryable();
        }

        [Fact]
        public void AndGroup()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.ExecuteDynamicQuery(_books, new DynamicQueryGroup()
            {
                Type = GroupType.And,
                Conditions = new List<DynamicQueryCondition>
                {
                    new DynamicQueryCondition {FieldName = "Type", Operator = DynamicQueryOperator.Equal, Value = BookType.Adventure},
                    new DynamicQueryCondition {FieldName = "Price", Operator = DynamicQueryOperator.Equal, Value = 400f}
                }
            });

            // Assert
            output.ShouldBe(_books.Skip(3));
        }

        [Fact]
        public void OrGroup()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.ExecuteDynamicQuery(_books, new DynamicQueryGroup()
            {
                Type = GroupType.Or,
                Conditions = new List<DynamicQueryCondition>
                {
                    new DynamicQueryCondition {FieldName = "Type", Operator = DynamicQueryOperator.Equal, Value = BookType.Adventure},
                    new DynamicQueryCondition {FieldName = "Price", Operator = DynamicQueryOperator.Equal, Value = 400f}
                }
            });

            // Assert
            output.ShouldBe(new[] {_books.ElementAt(0), _books.ElementAt(3)});
        }

        [Fact]
        public void NestedGroups()
        {
            // Arrange

            // Act
            var output = _dynamicQueryHelper.ExecuteDynamicQuery(_books, new DynamicQueryGroup
            {
                Type = GroupType.Or,
                Conditions = new List<DynamicQueryCondition>
                {
                    new DynamicQueryCondition {FieldName = "Type", Operator = DynamicQueryOperator.Equal, Value = BookType.Biography},
                },
                Groups = new List<DynamicQueryGroup>
                {
                    new DynamicQueryGroup
                    {
                        Type = GroupType.And,
                        Conditions = new List<DynamicQueryCondition>
                        {
                            new DynamicQueryCondition {FieldName = "Type", Operator = DynamicQueryOperator.Equal, Value = BookType.Adventure},
                            new DynamicQueryCondition {FieldName = "Price", Operator = DynamicQueryOperator.Equal, Value = 400f},
                        }
                    }
                }
            });

            // Assert
            output.ShouldBe(new[] {_books.ElementAt(1), _books.ElementAt(3)});
        }
    }
}