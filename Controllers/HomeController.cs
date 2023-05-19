using BookStore.Models;
using BookStore.Repository.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookEventRepository _bookEventRepository;


        public HomeController(ILogger<HomeController> logger,IBookEventRepository bookEventRepository)
        {
            _bookEventRepository = bookEventRepository;
            _logger = logger;
        }

        public async Task<ViewResult> Index()
        {
             var data = await _bookEventRepository.GetAllBookEvents();

            var myUpcommingEvents = 
                from item in data 
                orderby item.Date ascending
                where item.Type == 0 && (item.Date > DateTime.Now.Date || (item.Date == DateTime.Now.Date && item.StartTime.TimeOfDay >= DateTime.Now.TimeOfDay))
                select item;

            var myPastEvents = 
                from item in data 
                orderby item.Date ascending 
                where item.Type == 0 && (item.Date < DateTime.Now.Date || (item.Date == DateTime.Now.Date && item.StartTime.TimeOfDay < DateTime.Now.TimeOfDay)) 
                select item;

            ViewBag.UpcommingBookEvents = myUpcommingEvents;
            ViewBag.PastBookEvents = myPastEvents;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("book-event/{id}")]
        public async Task<ViewResult> BookEvent(int id)
        {
            
            var bookEvent = await _bookEventRepository.GetBookEventById(id);
            ViewBag.BookEvent = bookEvent;
            return View();
        }
    }
}
