using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Entities;
using Library.Interfaces;
using Library.Models.Request.User;
using Library.Models.Response;
using Library.Services.Auth;
using Library.Utilities.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Library.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        public UserService(UserManager<ApplicationUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions){
            _userManager = userManager;
            _jwtFactory  = jwtFactory;
            _jwtOptions  = jwtOptions.Value;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest user)
        {
            var identity = await GetClaimsIdentity(user.Username, user.Password);
            if (identity == null)
            {
                return new LoginResponse{
                    LoginStatus = (int)LoginStatus.Failed
                };
            }

            var jwt = await _jwtFactory.GenerateJwt(identity, _jwtFactory, user.Username, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return new LoginResponse{
                LoginStatus = (int)LoginStatus.Success,
                Token = jwt
            };
        }
        
        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            var m = await _userManager.CheckPasswordAsync(userToVerify, password);
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
        public async Task<bool> RegisterAsync(RegisterUserRequest model)
        {
            try
            {
                var result = await _userManager.CreateAsync(new ApplicationUser
                {
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.UserName
                }, model.Password);
                return result.Succeeded;
            }
            catch( Exception ex)
            {
                return false;
            }
        }
        
    }
}