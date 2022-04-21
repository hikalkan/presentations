using ECommerce.Ordering.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ECommerce.Ordering.Permissions;

public class OrderingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(OrderingPermissions.GroupName, L("Permission:Ordering"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OrderingResource>(name);
    }
}
