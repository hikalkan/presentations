namespace KonfDemo.ServerApp.Models.Liking
{
    public class LikingDto
    {
        public static LikingDto Empty { get; } = new LikingDto();

        public int LikeCount { get; set; }

        public int DislikeCount { get; set; }
    }
}