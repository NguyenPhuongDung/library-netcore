using System.Threading.Tasks;
using Library.Models.Request.User;

namespace Library.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(RegisterUserRequest model);
    }
}