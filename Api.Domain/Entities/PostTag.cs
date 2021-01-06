namespace Api.Domain.Entities
{
    public class PostTag : BaseEntity
    {
        public int PostId { get; set; }
        public Post Posts { get; set; }
        public int TagId { get; set; }
        public Tag Tags { get; set; }
    }
}