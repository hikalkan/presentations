using DemoApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DemoApp.Permissions
{
    public class DemoAppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DemoAppPermissions.GroupName);
            //Define your own permissions here. Example:
            myGroup.AddPermission("CanIncreaseValue", L("CanIncreaseValue"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DemoAppResource>(name);
        }
    }
}
