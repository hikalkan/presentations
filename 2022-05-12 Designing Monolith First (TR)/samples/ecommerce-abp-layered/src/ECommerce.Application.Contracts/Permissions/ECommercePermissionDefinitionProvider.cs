using ECommerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ECommerce.Permissions;

public class ECommercePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ECommercePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ECommercePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ECommerceResource>(name);
    }
}
