using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Models.Models;
using DataAccessLayer.ViewModels.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAdviceBL.Controllers.Interfaces;

namespace MyAdviceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private IBusinessBL BusinessBL;

        public BusinessController(IBusinessBL businessBL)
        {
            BusinessBL = businessBL;
        }

        /// <summary>
        /// Gets all the Business
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BusinessVM> GetBusiness()
        {
            var result = BusinessBL.GetBusiness();
            return result;
        }

        /// <summary>
        /// Gets all the Business by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("userId")]
        public IEnumerable<BusinessVM> GetBusinessByUserId(int userId)
        {
            var result = BusinessBL.GetBusinessByUserId(userId);
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("businessId")]
        public BusinessVM GetBusinessByBusinessId(int businessId)
        {
            var result = BusinessBL.GetBusinessByBusinessId(businessId);
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// Creates new Business
        /// </summary>
        /// <param name="businessVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertBusiness(BusinessVM businessVM)
        {
            var result = BusinessBL.InsertBusiness(businessVM);
            if (result != null) return Ok(result);
            else return BadRequest();
        }

        /// <summary>
        /// Updates the Business
        /// </summary>
        /// <param name="businessVM"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateBusiness(BusinessVM businessVM)
        {
            var result = BusinessBL.UpdateBusiness(businessVM);
            if (result != null) return Ok(result);
            else return BadRequest();
        }



    }
}