using DynamicQuerySample.Books;
using DynamicQuerySample.Books.Dtos;
using AutoMapper;

namespace DynamicQuerySample
{
    public class DynamicQuerySampleApplicationAutoMapperProfile : Profile
    {
        public DynamicQuerySampleApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>(MemberList.Source);
        }
    }
}