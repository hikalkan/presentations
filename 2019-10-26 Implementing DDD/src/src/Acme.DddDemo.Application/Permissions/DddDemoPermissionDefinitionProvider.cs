using Acme.DddDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.DddDemo.Permissions
{
    public class DddDemoPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DddDemoPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(DddDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DddDemoResource>(name);
        }
    }
}
