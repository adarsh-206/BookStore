using BookStore.Data.Entity;
using BookStore.Models.Book;
using BookStore.Models.Comment;
using BookStore.Models.User;
using BookStore.Repository.Book;
using BookStore.Repository.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookStore.Controllers
{
    [Authorize]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IBookEventRepository _bookEventRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<UserModel> _userManager;

        public UserController(UserManager<UserModel> userManager,IBookEventRepository bookEventRepository, ICommentRepository commentRepository)
        {
            _bookEventRepository = bookEventRepository;
            _commentRepository = commentRepository;
            _userManager = userManager;
        }

        public async Task<ViewResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var data = await _bookEventRepository.GetAllBookEvents();

            var myUpcommingEvents = 
                from item in data 
                orderby item.Date ascending
                where (item.Type == 0 || item.User.Id == user.Id) && (item.Date > DateTime.Now.Date || (item.Date == DateTime.Now.Date && item.StartTime.TimeOfDay >= DateTime.Now.TimeOfDay)) 
                select item;

            var myPastEvents = 
                from item in data 
                orderby item.Date ascending 
                where (item.Type == 0 || item.User.Id == user.Id) && (item.Date < DateTime.Now.Date || (item.Date == DateTime.Now.Date && item.StartTime.TimeOfDay < DateTime.Now.TimeOfDay)) 
                select item;

            ViewBag.UpcommingBookEvents = myUpcommingEvents;
            ViewBag.PastBookEvents = myPastEvents;
            return View();
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> Create(BookEventModel bookEventModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var result = await _bookEventRepository.AddNewEvent(bookEventModel,user);

                if(result > 0)
                {
                    return RedirectToAction("book-event", "User", new { id = result });
                }

            }
            return View();
        }

        [HttpGet]
        [Route("book-event/{id}")]
        public async Task<ViewResult> BookEvent(int id)
        {
            
            var bookEvent = await _bookEventRepository.GetBookEventById(id);
            // JsonConvert.SerializeObject(bookEvent, Formatting.Indented);

            if(bookEvent == null) 
            {
                ModelState.AddModelError("","Not Found!");
                return View();
            }

            var bookModel = new BookEventModel() 
            {
                Title = bookEvent.Title,
                Date = bookEvent.Date,
                Location = bookEvent.Location,
                StartTime = bookEvent.StartTime,
                Type = bookEvent.Type,
                Duration = bookEvent.Duration,
                OtherDetails = bookEvent.OtherDetails,
                Description = bookEvent.Description,
                InviteByEmail = bookEvent.InviteByEmail
            };



            if(bookEvent.Type == 0)
            {
                ViewBag.BookEvent = bookEvent;
                return View();
            } 


            else
            {
                UserModel user = await _userManager.GetUserAsync(HttpContext.User);
                String[] invites = bookEvent.InviteByEmail.Split(",");
                if(bookEvent.User.Id == user.Id || invites.Contains(user.NormalizedEmail))
                {
                    ViewBag.BookEvent = bookEvent;
                    return View();
                }
            }


            ModelState.AddModelError("","Not Found!");
            return View();

        }

        [HttpGet]
        [Route("My-Events")]
        public async Task<ViewResult> MyEvents()
        {
            UserModel user = await _userManager.GetUserAsync(HttpContext.User);

            var data = await _bookEventRepository.GetAllBookEvents();

            var myUpcommingEvents = 
                from item in data 
                orderby item.Date ascending
                where item.User.Id == user.Id && (item.Date > DateTime.Now.Date || (item.Date == DateTime.Now.Date && item.StartTime.TimeOfDay >= DateTime.Now.TimeOfDay)) 
                select item;

            var myPastEvents = 
                from item in data 
                orderby item.Date ascending 
                where item.User.Id == user.Id &&  (item.Date < DateTime.Now.Date || (item.Date == DateTime.Now.Date && item.StartTime.TimeOfDay < DateTime.Now.TimeOfDay))
                select item;

            ViewBag.UpcommingBookEvents = myUpcommingEvents;
            ViewBag.PastBookEvents = myPastEvents;
            
            return View();
        }

        [HttpGet]
        [Route("Invitations")]
        public async Task<ViewResult> Invitations()
        {

            UserModel user = await _userManager.GetUserAsync(HttpContext.User);

            var data = await _bookEventRepository.GetAllBookEvents();
            
            var myUpcommingEvents = 
                from item1 in data 
                orderby item1.Date ascending
                where CheckInvite(item1.InviteByEmail,user) == true && (item1.Date > DateTime.Now.Date || (item1.Date == DateTime.Now.Date && item1.StartTime.TimeOfDay >= DateTime.Now.TimeOfDay)) 
                select item1;

            var myPastEvents = 
                from item2 in data 
                orderby item2.Date ascending 
                where CheckInvite(item2.InviteByEmail,user) == true &&  (item2.Date < DateTime.Now.Date || (item2.Date == DateTime.Now.Date && item2.StartTime.TimeOfDay < DateTime.Now.TimeOfDay))
                select item2;

            ViewBag.UpcommingBookEvents = myUpcommingEvents;
            ViewBag.PastBookEvents = myPastEvents;

            return View();
        }

        bool CheckInvite(String invites,UserModel user)
        {
            if(invites == null) return false;

            String[] emails = invites.Split(",");

            foreach (var item in emails)
            {
                if(item.ToUpper() == user.NormalizedUserName) return true;
            }

            return false;
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<ViewResult> Edit(int id)
        {
            var bookEvent = await _bookEventRepository.GetBookEventById(id);
            UserModel user = await _userManager.GetUserAsync(HttpContext.User);

            if(bookEvent == null)
            {
                ModelState.AddModelError("","Event Not found!");
                return View();
            }
            else if(user != bookEvent.User)
            {
                ModelState.AddModelError("","You don't have the permissions to edit this event!");
                    ViewBag.Id = bookEvent.Id;
                    return View();
            }
            else
            {
                BookEventModel bookModel = new BookEventModel(){

                    Id = bookEvent.Id,
                    Title = bookEvent.Title,
                    Date = bookEvent.Date,
                    Location = bookEvent.Location,
                    StartTime = bookEvent.StartTime,
                    Type = bookEvent.Type,
                    Duration = bookEvent.Duration,
                    OtherDetails = bookEvent.OtherDetails,
                    Description = bookEvent.Description,
                    InviteByEmail = bookEvent.InviteByEmail
                };
                ViewBag.Id = bookEvent.Id;
                return View(bookModel);
            }

        }

        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(BookEventModel bookEventModel,int id)
        {
            if(ModelState.IsValid){
                await _bookEventRepository.UpdateEvent(bookEventModel,id);
                return RedirectToAction("book-event", "User", new { id = id });
            }
            
            ViewBag.Id = id;
            return View(bookEventModel);
        }

        [HttpPost]
        [Route("comment/{id}")]
        public async Task<IActionResult> Comment(CommentModel comment, int id)
        {
            if(ModelState.IsValid)
            {
                UserModel user = await _userManager.GetUserAsync(HttpContext.User);
                BookEventEntity bookEvent = await _bookEventRepository.GetBookEventById(id);

                CommentModel commentModel = new CommentModel()
                {
                    Text = comment.Text,
                    User = user,
                    Book = bookEvent,
                    CreatedAt = DateTime.Now
                };
                int res = await _commentRepository.AddNewComment(commentModel);
            }
            return RedirectToAction("book-event", "User", new { id = id });

            // return RedirectToAction()
        }
    }
}
