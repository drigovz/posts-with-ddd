using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.PostsTags
{
    public interface IPostTagService
    {
        Task<IEnumerable<PostTag>> GetAsync();
        Task<PostTag> GetByIdAsync(int id);
        Task<PostTag> AddAsync(PostTag post);
        Task<PostTag> UpdateAsync(PostTag post);
        Task<bool> DeleteAsync(int id);
    }
}