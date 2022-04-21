using Volo.Abp.Reflection;

namespace ECommerce.Customers.Permissions;

public class CustomersPermissions
{
    public const string GroupName = "Customers";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CustomersPermissions));
    }
}
