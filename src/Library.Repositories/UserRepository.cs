using System.Threading.Tasks;
using Library.Entities;
using Library.Interfaces;
using Library.Models.Request.User;
using Microsoft.AspNetCore.Identity;

namespace Library.Repositories
{
    // public class UserRepository : IUserRepository
    // {
    //     private readonly UserManager<ApplicationUser> UserManager;
    //     public UserRepository(UserManager<ApplicationUser> userManager){
    //         UserManager = userManager;
    //     }
    //     public async Task<bool> RegisterAsync(RegisterUserRequest model)
    //     {
    //         var result = await UserManager.CreateAsync(new ApplicationUser
    //         {
    //             Email = model.Email,
    //             PhoneNumber = model.PhoneNumber,
    //             UserName = model.UserName
    //         }, model.Password);
    //         return result.Succeeded;
    //     }
    // }
}