using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace ECommerce.Customers.Blazor.Menus;

public class CustomersMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(CustomersMenus.Prefix, displayName: "Customers", "/Customers", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
