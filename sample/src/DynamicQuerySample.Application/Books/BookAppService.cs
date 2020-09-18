using System;
using DynamicQuerySample.Permissions;
using DynamicQuerySample.Books.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DynamicQuerySample.Books
{
    public class BookAppService : CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto, CreateUpdateBookDto>,
        IBookAppService
    {
        private readonly IBookRepository _repository;
        
        public BookAppService(IBookRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
