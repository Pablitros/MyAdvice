using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models.Models;
using DataAccessLayer;
using DataAccessLayer.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authentication;
using MyAdviceWebApi.MailHelper;
using MyAdviceBL.Controllers.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MyAdviceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBL UserBL;
        public UserController(IUserBL userBL)
        {
            UserBL = userBL;
        }

        /// <summary>
        /// Return a list with all the Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(UserBL.GetAllUser());
        }
        /// <summary>
        /// Creates an user
        /// </summary>
        /// <param name="userVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateUser(UserVM userVM)
        {
            var result = UserBL.CreateUser(userVM);
            if (result != null)  return Ok(result);
            else return BadRequest();
        }

        /// <summary>
        /// Checks if the user is or is not on the database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("login")]
        public UserVM Login(string email, string password)
        {
            var result = UserBL.Login(email, password);
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// Updates the user
        /// </summary>
        /// <param name="userVM"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateUser(UserVM userVM)
        {
            var result = UserBL.UpdateUser(userVM);
            if (result != null) return Ok(result);
            else return BadRequest();
        }

        
    }
}
