using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.PostsTags
{
    public interface IPostTagService
    {
        Task<IEnumerable<PostTag>> GetAsync();
        Task<PostTag> AddAsync(PostTag postTag);
        Task<bool> DeleteAsync(int id);
    }
}