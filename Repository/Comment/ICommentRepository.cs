using BookStore.Models.Comment;
using System.Threading.Tasks;

namespace BookStore.Repository.Comment
{
    public interface ICommentRepository
    {
        Task<CommentEntity> GetBookEventById(int id);

        Task<int> AddNewComment(CommentModel commentModel);


    }
}