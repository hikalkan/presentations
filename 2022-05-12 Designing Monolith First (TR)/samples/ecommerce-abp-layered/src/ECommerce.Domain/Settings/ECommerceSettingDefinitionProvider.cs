using Volo.Abp.Settings;

namespace ECommerce.Settings;

public class ECommerceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ECommerceSettings.MySetting1));
    }
}
