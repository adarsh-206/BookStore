using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Models.User;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Repository.User
{
    public class UserRepository : IUserRepository
    {

        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signinManager;

        public UserRepository(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(UserSignUp userSignUp)
        {
            var user = new UserModel()
            {
                Email = userSignUp.Email,
                UserName = userSignUp.Email,
                FirstName = userSignUp.FirstName,
                LastName = userSignUp.LastName,
            };
            var result = await _userManager.CreateAsync(user, userSignUp.Password);

            return result;
        }

        public async Task<SignInResult> PasswordSigninAsync(UserSignInModel userSignIn)
        {
            var result = await _signinManager.PasswordSignInAsync(userSignIn.Email, userSignIn.Password, userSignIn.Remember, false);
            return result;
        }

        public async Task Logout()
        {
            await _signinManager.SignOutAsync();
        }

    }
}
