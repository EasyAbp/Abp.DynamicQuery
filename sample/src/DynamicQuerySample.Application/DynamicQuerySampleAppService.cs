using System;
using System.Collections.Generic;
using System.Text;
using DynamicQuerySample.Localization;
using Volo.Abp.Application.Services;

namespace DynamicQuerySample
{
    /* Inherit your application services from this class.
     */
    public abstract class DynamicQuerySampleAppService : ApplicationService
    {
        protected DynamicQuerySampleAppService()
        {
            LocalizationResource = typeof(DynamicQuerySampleResource);
        }
    }
}
