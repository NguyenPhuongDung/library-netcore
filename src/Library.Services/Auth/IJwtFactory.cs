using System.Security.Claims;
using System.Threading.Tasks;
using Library.Entities;
using Library.Models.Response;
using Newtonsoft.Json;

namespace Library.Services.Auth
{
    public interface IJwtFactory
    {
        Task<LoginResponse> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory,string userName, JwtIssuerOptions jwtOptions);
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(ApplicationUser user);
    }
}