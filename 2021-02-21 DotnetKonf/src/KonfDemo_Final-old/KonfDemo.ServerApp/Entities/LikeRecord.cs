using Volo.Abp.Domain.Entities;

namespace KonfDemo.ServerApp.Entities
{
    public class LikeRecord : BasicAggregateRoot<string>
    {
        public int LikeCount { get; set; }
        
        public int DislikeCount { get; set; }

        private LikeRecord()
        {

        }

        public LikeRecord(string id)
            : base(id)
        {

        }
    }
}
