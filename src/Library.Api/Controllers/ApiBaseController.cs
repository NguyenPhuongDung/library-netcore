using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        protected IMapper Mapper { get; set; }

        public ApiBaseController(IMapper mapper)
        {
            Mapper = mapper;
        }

        // protected static Response Success()
        // {
        //     return new Response((int)GeneralErrors.Success, null);
        // }

        // protected static Response<T> Success<T>(T result)
        // {
        //     return new Response<T>((int)GeneralErrors.Success, null, result);
        // }

        // protected static Response Failed()
        // {
        //     return new Response((int)GeneralErrors.Failed, null);
        // }

        // protected static Response Failed(int errorCode, string message)
        // {
        //     return new Response(errorCode, message);
        // }

        // protected static Response<T> Failed<T>(T result)
        // {
        //     return new Response<T>((int)GeneralErrors.Failed, null, result);
        // }

        // protected static Response<T> Failed<T>(int errorCode, string message, T result)
        // {
        //     return new Response<T>(errorCode, message, result);
        // }
        protected static ResponseResult<T> Handle<T>(int errorCode, string message, T result)
        {
            return new ResponseResult<T>
            {
                ErrorCode = errorCode,
                ErrorMessage = message,
                Result = result
            };
        }
        protected ObjectResult Unauthorized(object obj)
        {
            return StatusCode((int)HttpStatusCode.Unauthorized, obj);
        }

        protected ObjectResult Forbid(object obj)
        {
            return StatusCode((int)HttpStatusCode.Forbidden, obj);
        }
    }

    public class ResponseResult<T>
    {
        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
        public T Result { get; set; }
    }
}
