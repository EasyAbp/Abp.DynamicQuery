using DynamicQuerySample.Books.Dtos;
using DynamicQuerySample.Web.Pages.Books.Book.ViewModels;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace DynamicQuerySample.Web
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class BookDtoToCreateEditBookViewModelMapper : MapperBase<BookDto, CreateEditBookViewModel>
    {
        public override partial CreateEditBookViewModel Map(BookDto source);

        public override partial void Map(BookDto source, CreateEditBookViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateEditBookViewModelToCreateUpdateBookDtoMapper : MapperBase<CreateEditBookViewModel, CreateUpdateBookDto>
    {
        public override partial CreateUpdateBookDto Map(CreateEditBookViewModel source);

        public override partial void Map(CreateEditBookViewModel source, CreateUpdateBookDto destination);
    }
}
