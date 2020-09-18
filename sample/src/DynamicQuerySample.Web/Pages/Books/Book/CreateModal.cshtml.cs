using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicQuerySample.Books;
using DynamicQuerySample.Books.Dtos;
using DynamicQuerySample.Web.Pages.Books.Book.ViewModels;

namespace DynamicQuerySample.Web.Pages.Books.Book
{
    public class CreateModalModel : DynamicQuerySamplePageModel
    {
        [BindProperty]
        public CreateEditBookViewModel ViewModel { get; set; }

        private readonly IBookAppService _service;

        public CreateModalModel(IBookAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditBookViewModel, CreateUpdateBookDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}