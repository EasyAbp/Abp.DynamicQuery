using System;
using DynamicQuerySample.Books.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DynamicQuerySample.Books
{
    public interface IBookAppService :
        ICrudAppService< 
            BookDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateBookDto,
            CreateUpdateBookDto>
    {

    }
}