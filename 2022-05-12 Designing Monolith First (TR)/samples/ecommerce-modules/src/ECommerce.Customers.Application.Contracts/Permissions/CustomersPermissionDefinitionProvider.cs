using ECommerce.Customers.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ECommerce.Customers.Permissions;

public class CustomersPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CustomersPermissions.GroupName, L("Permission:Customers"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CustomersResource>(name);
    }
}
