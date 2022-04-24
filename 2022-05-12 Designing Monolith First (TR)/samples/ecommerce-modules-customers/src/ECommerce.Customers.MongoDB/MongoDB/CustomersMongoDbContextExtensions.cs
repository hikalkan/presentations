using Volo.Abp;
using Volo.Abp.MongoDB;

namespace ECommerce.Customers.MongoDB;

public static class CustomersMongoDbContextExtensions
{
    public static void ConfigureCustomers(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
