using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace DynamicQuerySample.Web
{
    [Dependency(ReplaceServices = true)]
    public class DynamicQuerySampleBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DynamicQuerySample";
    }
}
