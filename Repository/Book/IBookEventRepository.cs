using BookStore.Data.Entity;
using BookStore.Models.Book;
using BookStore.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Repository.Book
{
    public interface IBookEventRepository
    {
        Task<int> AddNewEvent(BookEventModel bookEventModel, UserModel user);
        Task<BookEventEntity> UpdateEvent(BookEventModel bookEventModel, int id);


        Task<BookEventEntity> GetBookEventById(int id);

        Task<List<BookEventEntity>> GetAllBookEvents();

        //IEnumerable<BookEventModel> GetBookEvents();
        //BookEventModel GetBookEventByID(int bookId);
        //void InsertBookEvent(BookEventModel book);
        //void DeleteBookEvent(int bookID);
        //void UpdateBookEvent(BookEventModel book);
        //void Save();
    }
}