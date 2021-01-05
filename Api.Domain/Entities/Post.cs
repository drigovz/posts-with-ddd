using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Api.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool? IsActive { get; set; } = true;
        public int NumLikes { get; set; } = 0;
        public int Views { get; set; } = 0;
        public int CategoryId { get; set; }
        public ICollection<PostTag> Tags { get; set; } = new Collection<PostTag>();
        public ICollection<Comment> Comments { get; set; } = new Collection<Comment>();
    }
}