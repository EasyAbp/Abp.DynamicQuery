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

        protected override Task<IQueryable<Book>> CreateFilteredQueryAsync(GetListInput input)
        {
            return Task.FromResult(_repository.ExecuteDynamicQuery(input.FilterGroup));
        }

        protected override Task<Book> MapToEntityAsync(CreateUpdateBookDto createInput)
        {
            return Task.FromResult(new Book(
                GuidGenerator.Create(),
                createInput.Name,
                createInput.Type,
                createInput.PublishDate,
                createInput.Price));
        }

        protected override Task MapToEntityAsync(CreateUpdateBookDto updateInput, Book entity)
        {
            entity.Update(
                updateInput.Name,
                updateInput.Type,
                updateInput.PublishDate,
                updateInput.Price);
            return Task.CompletedTask;
        }

        [HttpPost]    // Need this for receiving dynamic query parameters 
        public override Task<PagedResultDto<BookDto>> GetListAsync(GetListInput input)
        {
            return base.GetListAsync(input);
        }
    }
}
