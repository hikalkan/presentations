using System;

namespace SimpleEventBusUsage.Shared
{
    public class StockCountChangedEvent
    {
        public Guid ProductId { get; set; }

        public int NewCount { get; set; }

        public StockCountChangedEvent()
        {
            
        }

        public StockCountChangedEvent(Guid productId, int newCount)
        {
            ProductId = productId;
            NewCount = newCount;
        }
    }
}
