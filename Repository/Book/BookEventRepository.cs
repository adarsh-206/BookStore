using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Data.Entity;
using BookStore.Models.Book;
using BookStore.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.Book
{
    public class BookEventRepository: IBookEventRepository
    {

        private readonly ApplicationDbContext _context;

        public BookEventRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<int> AddNewEvent(BookEventModel bookEventModel,UserModel user)
        {
            
            BookEventEntity newEvent = new BookEventEntity();
            // {
            newEvent.Title = bookEventModel.Title;
            newEvent.Date = bookEventModel.Date;
            newEvent.Location = bookEventModel.Location;
            newEvent.StartTime = bookEventModel.StartTime;
            newEvent.Type = bookEventModel.Type;
            newEvent.Duration = bookEventModel.Duration;
            newEvent.OtherDetails = bookEventModel.OtherDetails;
            newEvent.Description = bookEventModel.Description;
            newEvent.InviteByEmail = ( bookEventModel.InviteByEmail == null ? "" : bookEventModel.InviteByEmail.ToUpper());
            newEvent.User = user;
            // };

            await _context.BookEvents.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            return newEvent.Id;
        }

        public async Task<BookEventEntity> GetBookEventById(int id)
        {
            BookEventEntity result = await _context.BookEvents
                .Include(c => c.Comments).Include("Comments.User")
                .FirstOrDefaultAsync(data => data.Id == id);
            return result;
        }


        public async Task<List<BookEventEntity>> GetAllBookEvents()
        {
            List<BookEventEntity> result = await _context.BookEvents.Include(r => r.User).ToListAsync();
            return result;

        }

        public async Task<BookEventEntity> UpdateEvent(BookEventModel bookEventModel,int id)
        {

            var res = await _context.BookEvents.FindAsync(id);
            
            res.Title = bookEventModel.Title;
            res.Date = bookEventModel.Date;
            res.Location = bookEventModel.Location;
            res.StartTime = bookEventModel.StartTime;
            res.Type = bookEventModel.Type;
            res.Duration = bookEventModel.Duration;
            res.OtherDetails = bookEventModel.OtherDetails;
            res.Description = bookEventModel.Description;
            res.InviteByEmail = bookEventModel.InviteByEmail;

            await _context.SaveChangesAsync();

            return res;
        }

    }
}
