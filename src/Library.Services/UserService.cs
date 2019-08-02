using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Entities;
using Library.Interfaces;
using Library.Models.Request.User;
using Library.Models.Response;
using Library.Services.Auth;
using Library.Utilities.Dictionaries;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using AutoMapper;

namespace Library.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;    
        private readonly IMapper Mapper;
        public UserService(UserManager<ApplicationUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions, IMapper mapper){
            _userManager = userManager;
            _jwtFactory  = jwtFactory;
            _jwtOptions  = jwtOptions.Value;
            Mapper = mapper;
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

            var jwt = await _jwtFactory.GenerateJwt(identity, _jwtFactory, user.Username, _jwtOptions);
            jwt.LoginStatus = (int)LoginStatus.Success;
            return jwt;
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
        public async Task<bool> RegisterAsync(RegisterUserRequest registerUser)
        {
            var accountRegister = Mapper.Map<ApplicationUser>(registerUser);
            var result = await _userManager.CreateAsync(accountRegister, registerUser.Password);
            return result.Succeeded;
        }
        
    }
}