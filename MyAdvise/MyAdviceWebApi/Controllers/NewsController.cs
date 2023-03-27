using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MyAdviceBL.Controllers.Interfaces;

namespace MyAdviceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {

        private INewsBL NewsBL;

        public NewsController(INewsBL newsBL)
        {
            NewsBL = newsBL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="news"></param>
        [HttpPost]
        public IActionResult InsertNews(NewsVM news)
        {
            var result = NewsBL.InsertNews(news);
            if (result != null) return Ok(result);
            else return BadRequest();
        }
    }
}