using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> AddAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
    }
}