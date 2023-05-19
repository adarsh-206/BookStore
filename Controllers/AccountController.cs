using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Repository.Book;
using BookStore.Repository.User;

namespace BookStore.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {

        private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("signup")]
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUp userSignup)
        {

            if (ModelState.IsValid)
            {
                var result = await _userRepository.CreateUserAsync(userSignup);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
            }
            return View(userSignup);

        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserSignInModel userSign)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.PasswordSigninAsync(userSign);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","User", new { area = "" });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }

            return View(userSign);

        }


        [Route("logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _userRepository.Logout();
            return RedirectToAction("Index","Home");
        }

    }
}
