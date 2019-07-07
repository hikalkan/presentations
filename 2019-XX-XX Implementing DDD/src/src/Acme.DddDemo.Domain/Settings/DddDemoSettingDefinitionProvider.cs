using Volo.Abp.Settings;

namespace Acme.DddDemo.Settings
{
    public class DddDemoSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(DddDemoSettings.MySetting1));
        }
    }
}
