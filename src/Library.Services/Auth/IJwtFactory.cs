using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Library.Services.Auth
{
    public interface IJwtFactory
    {
        Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory,string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings);
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
    }
}