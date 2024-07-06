namespace Acme.BookStore.Permissions;

public static class BookStorePermissions
{
    public const string GroupName = "BookStore";
    
    public const string Books = GroupName + ".Books";
    public const string Books_Create = GroupName + ".Books.Create";
    public const string Books_Delete = GroupName + ".Books.Delete";
}
