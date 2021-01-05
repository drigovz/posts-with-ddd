namespace Api.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public int PostId { get; set; }
    }
}