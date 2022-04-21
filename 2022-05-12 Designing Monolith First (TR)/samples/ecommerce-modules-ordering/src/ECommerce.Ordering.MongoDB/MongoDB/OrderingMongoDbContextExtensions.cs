using Volo.Abp;
using Volo.Abp.MongoDB;

namespace ECommerce.Ordering.MongoDB;

public static class OrderingMongoDbContextExtensions
{
    public static void ConfigureOrdering(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
