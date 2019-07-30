using System.Threading.Tasks;
using Library.Models.Request.User;
using Library.Models.Response;

namespace Library.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponse> LoginAsync(LoginRequest model);
        Task<bool> RegisterAsync(RegisterUserRequest model);
    }
}