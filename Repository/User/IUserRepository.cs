using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateUserAsync(UserSignUp userSignUp);

        Task<SignInResult> PasswordSigninAsync(UserSignInModel userSignIn);
        Task Logout();


    }
}