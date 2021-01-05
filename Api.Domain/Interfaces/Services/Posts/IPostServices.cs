using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Posts
{
    public interface IPostServices
    {
        Task<IEnumerable<Post>> GetAsync();
        Task<Post> GetByIdAsync(int id);
        Task<Post> AddAsync(Post post);
        Task<Post> UpdateAsync(Post post);
        Task<bool> DeleteAsync(int id);
    }
}