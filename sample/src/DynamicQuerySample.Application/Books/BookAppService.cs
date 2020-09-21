using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicQuerySample.Books.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DynamicQuerySample.Books
{
    public class BookAppService : CrudAppService<Book, BookDto, Guid, GetListInput, CreateUpdateBookDto, CreateUpdateBookDto>,
        IBookAppService
    {
        private readonly IBookRepository _repository;
        
        public BookAppService(IBookRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override IQueryable<Book> CreateFilteredQuery(GetListInput input)
        {
            return _repository.ExecuteDynamicQuery(input.FilterGroup);
        }

        [HttpPost]    // Need this for receiving dynamic query parameters 
        public override Task<PagedResultDto<BookDto>> GetListAsync(GetListInput input)
        {
            return base.GetListAsync(input);
        }
    }
}
