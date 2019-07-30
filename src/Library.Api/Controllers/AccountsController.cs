using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Models.Request.User;
using Library.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        protected readonly IUserService _userService;

        public AccountsController(IUserService userService)
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
            if (ModelState.IsValid)
            {
                try
                {
                    var x = await _userService.RegisterAsync(registerUser);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest credentials)
        {
            var result = await _userService.LoginAsync(credentials);
            if(result.LoginStatus == (int)LoginStatus.Success)
            {
                return new OkObjectResult(result);
            }
            else 
            {
                return BadRequest();
            }
        }

    }
}