using System.Collections.Generic;
using Core.DTO;
using Core.Interface;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashtagController
    {
        IHashtagService hashtag;
        public HashtagController(IHashtagService hashtag)
        {
            this.hashtag = hashtag;
        }

        [HttpGet]
        public ActionResult<List<Core.DTO.Hashtag>> Get()
        {
            var hashtagList = this.hashtag.Get();
            return hashtagList;
        }
        
    }
}