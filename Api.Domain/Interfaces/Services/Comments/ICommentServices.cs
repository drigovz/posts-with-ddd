using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Comments
{
    public interface ICommentServices
    {
        Task<IEnumerable<Comment>> GetAsync();
        Task<Comment> GetByIdAsync(int id);
        Task<Comment> AddAsync(Comment comment);
        Task<Comment> UpdateAsync(Comment comment);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Comment>> GetCommentsPostAsync(int postId);
    }
}