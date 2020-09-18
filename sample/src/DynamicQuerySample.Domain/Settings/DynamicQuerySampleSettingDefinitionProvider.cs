using Volo.Abp.Settings;

namespace DynamicQuerySample.Settings
{
    public class DynamicQuerySampleSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(DynamicQuerySampleSettings.MySetting1));
        }
    }
}
