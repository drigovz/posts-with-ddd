using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.PostsTags;

namespace Api.Service.Services
{
    public class PostsTagsService : IPostTagService
    {
        private readonly IRepository<PostTag> _repository;

        public PostsTagsService(IRepository<PostTag> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PostTag>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<PostTag> AddAsync(PostTag postTag)
        {
            return await _repository.AddAsync(postTag);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}