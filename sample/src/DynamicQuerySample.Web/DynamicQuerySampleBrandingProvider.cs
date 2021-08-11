using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace DynamicQuerySample.Web
{
    [Dependency(ReplaceServices = true)]
    public class DynamicQuerySampleBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DynamicQuerySample";
    }
}
