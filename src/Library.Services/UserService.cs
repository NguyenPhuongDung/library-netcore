using System.Threading.Tasks;
using Library.Entities;
using Library.Interfaces;
using Library.Models.Request.User;
using Microsoft.AspNetCore.Identity;

namespace Library.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<ApplicationUser> UserManager;
        public UserService(UserManager<ApplicationUser> userManager){
            UserManager = userManager;
        }
        public async Task<bool> RegisterAsync(RegisterUserRequest model)
        {
            var result = await UserManager.CreateAsync(new ApplicationUser
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            }, model.Password);
            return result.Succeeded;
        }
        
    }
}