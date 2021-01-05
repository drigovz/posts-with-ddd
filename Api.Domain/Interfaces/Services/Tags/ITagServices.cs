using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Tags
{
    public interface ITagServices
    {
        Task<IEnumerable<Tag>> GetAsync();
        Task<Tag> GetByIdAsync(int id);
        Task<Tag> AddAsync(Tag tag);
        Task<Tag> UpdateAsync(Tag tag);
        Task<bool> DeleteAsync(int id);
    }
}