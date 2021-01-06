using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Tags;

namespace Api.Service.Services
{
    public class TagsService : ITagServices
    {
        private readonly IRepository<Tag> _repository;

        public TagsService(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tag>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            return await _repository.AddAsync(tag);
        }

        public async Task<Tag> UpdateAsync(Tag tag)
        {
            return await _repository.UpdateAsync(tag);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}