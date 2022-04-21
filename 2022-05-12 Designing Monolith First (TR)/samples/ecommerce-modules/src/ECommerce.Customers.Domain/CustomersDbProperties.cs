namespace ECommerce.Customers;

public static class CustomersDbProperties
{
    public static string DbTablePrefix { get; set; } = "Customers";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Customers";
}
