using DynamicQuerySample.Books.Dtos;
using DynamicQuerySample.Web.Pages.Books.Book.ViewModels;
using AutoMapper;

namespace DynamicQuerySample.Web
{
    public class DynamicQuerySampleWebAutoMapperProfile : Profile
    {
        public DynamicQuerySampleWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<BookDto, CreateEditBookViewModel>();
            CreateMap<CreateEditBookViewModel, CreateUpdateBookDto>();
        }
    }
}