using System.Threading.Tasks;

namespace DynamicQuerySample.Web.Pages.Books.Book
{
    public class IndexModel : DynamicQuerySamplePageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
