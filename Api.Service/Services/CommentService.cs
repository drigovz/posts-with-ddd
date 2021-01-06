using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Comments;

namespace Api.Service.Services
{
    public class CommentService : ICommentServices
    {
        private readonly IRepository<Comment> _repository;

        public CommentService(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Comment>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Comment> AddAsync(Comment comment)
        {
            return await _repository.AddAsync(comment);
        }

        public async Task<Comment> UpdateAsync(Comment comment)
        {
            return await _repository.UpdateAsync(comment);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetCommentsPostAsync(int postId)
        {
            var result = await _repository.GetAsync();
            return result.ToList().Where(x => x.PostId == postId).ToList();
        }
    }
}