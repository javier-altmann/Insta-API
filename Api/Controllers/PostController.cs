using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService post;
        public PostController(IPostService post)
        {
            this.post = post;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<PostHashtags>> Get()
        {
            var postHashtagsResult = post.Get();
            return postHashtagsResult;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Core.DTO.Post post)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (post == null)
            {
                return NotFound(post);
            }
            var postResponse = this.post.Post(post); 
            
            return Created("", postResponse);

        }

    }
}
