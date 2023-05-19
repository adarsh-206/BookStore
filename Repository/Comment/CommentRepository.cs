using BookStore.Data;
using BookStore.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository.Comment
{
    public class CommentRepository: ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<CommentEntity> GetBookEventById(int id)
        {
            var result = await _context.Comments.FindAsync(id);
            return result;
        }

        // public async Task<CommentEntity> GetAllComment()
        // {
        //     var result = await _context.Comments.ToList();
        //     return result;
        // }

        public async Task<int> AddNewComment(CommentModel commentModel)
        {

            CommentEntity commentEntity = new CommentEntity()
            {
                Text = commentModel.Text,
                UserId = commentModel.User.Id,
                BookEventId = commentModel.Book.Id,
                User = commentModel.User,
                BookEvent = commentModel.Book,
                CreatedAt = DateTime.Now
            };

            await _context.AddAsync(commentEntity);
            await _context.SaveChangesAsync();

            return commentEntity.Id;
        }

    }
}
