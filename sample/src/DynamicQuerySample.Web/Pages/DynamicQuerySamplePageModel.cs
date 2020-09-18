using DynamicQuerySample.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DynamicQuerySample.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class DynamicQuerySamplePageModel : AbpPageModel
    {
        protected DynamicQuerySamplePageModel()
        {
            LocalizationResourceType = typeof(DynamicQuerySampleResource);
        }
    }
}