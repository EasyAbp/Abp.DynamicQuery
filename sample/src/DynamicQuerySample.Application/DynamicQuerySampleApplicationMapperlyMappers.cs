using DynamicQuerySample.Books;
using DynamicQuerySample.Books.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace DynamicQuerySample
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class BookToBookDtoMapper : MapperBase<Book, BookDto>
    {
        public override partial BookDto Map(Book source);

        public override partial void Map(Book source, BookDto destination);
    }
}
