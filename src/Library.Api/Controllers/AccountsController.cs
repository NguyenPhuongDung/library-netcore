using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Entities;
using Library.Interfaces;
using Library.Models.Request.User;
using Library.Utilities.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ApiBaseController
    {
        protected readonly IUserService _userService;
        public AccountsController(IUserService userService, IMapper mapper) : base(mapper)
        {
            _userService = userService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterUserRequest registerUser)
        {
            var accountRegister = Mapper.Map<ApplicationUser>(registerUser);
            var result = await _userService.RegisterAsync(registerUser);
            if(!result)
            {
                return new BadRequestObjectResult("Something wrong!");
            }
            return new OkObjectResult("Account created");
        }
        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest credentials)
        {
            var result = await _userService.LoginAsync(credentials);
            if(result.LoginStatus == (int)LoginStatus.Success)
            {
                return new JsonResult(result);
            }
            else 
            {
                return BadRequest();
            }
        }

    }
}