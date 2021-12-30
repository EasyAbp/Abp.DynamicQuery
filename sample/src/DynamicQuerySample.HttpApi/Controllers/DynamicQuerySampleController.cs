using DynamicQuerySample.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DynamicQuerySample.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class DynamicQuerySampleController : AbpControllerBase
    {
        protected DynamicQuerySampleController()
        {
            LocalizationResource = typeof(DynamicQuerySampleResource);
        }
    }
}