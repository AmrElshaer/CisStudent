namespace Domain.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public CisStudent Student { get; set; }
        public int ReactionIndex { get; set; }
        public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}