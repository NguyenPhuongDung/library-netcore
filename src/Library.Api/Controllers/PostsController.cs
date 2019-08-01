using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Library.Entities;
using Library.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            try
            {
                var categories = _postService.GetAllPosts();
                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        //
        // GET: /Product/Details/5

        [HttpGet("{categoryId}")]
        public IActionResult Get(int categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest();
            }

            try
            {
                var category = _postService.GetPost(categoryId);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody]Post model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _postService.Add(model);

                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdatePost([FromBody]Post model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _postService.Update(model);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return Ok();
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {

            if (categoryId == null)
            {
                return BadRequest();
            }

            try
            {
                if (categoryId != null)
                {
                    _postService.Delete(categoryId);
                }
                else
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }



    }
}
