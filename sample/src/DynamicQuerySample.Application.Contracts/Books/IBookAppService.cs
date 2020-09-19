using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicQuerySample.Books.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DynamicQuerySample.Books
{
    public interface IBookAppService :
        ICrudAppService< 
            BookDto, 
            Guid, 
            GetListInput,
            CreateUpdateBookDto,
            CreateUpdateBookDto>
    {
    }
}