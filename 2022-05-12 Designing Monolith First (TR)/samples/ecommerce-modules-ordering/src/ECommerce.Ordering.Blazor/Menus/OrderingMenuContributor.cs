using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace ECommerce.Ordering.Blazor.Menus;

public class OrderingMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(OrderingMenus.Prefix, displayName: "Ordering", "/Ordering", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
