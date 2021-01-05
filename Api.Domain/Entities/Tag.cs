using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Api.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PostTag> Posts { get; set; } = new Collection<PostTag>();
    }
}