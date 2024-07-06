using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.Permissions;

public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BookStorePermissions.GroupName);
        
        var booksPermission = myGroup.AddPermission(BookStorePermissions.Books, new FixedLocalizableString("Books page"));
        booksPermission.AddChild(BookStorePermissions.Books_Create, new FixedLocalizableString("Create a new book"));
        booksPermission.AddChild(BookStorePermissions.Books_Delete, new FixedLocalizableString("Delete books"));
    }
}
