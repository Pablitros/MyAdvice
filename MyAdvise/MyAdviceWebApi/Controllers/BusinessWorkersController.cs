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
using MyAdviceBL.Controllers.Interfaces;

namespace MyAdviceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessWorkersController : ControllerBase
    {
        private IBusinessWorkersBL BusinessWorkersBL;

        public BusinessWorkersController(IBusinessWorkersBL businessWorkersBL)
        {
            BusinessWorkersBL = businessWorkersBL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("businessId")]
        public IEnumerable<BusinessWorkersVM> GetBusinessWorkersByBusinessId(int businessId)
        {
            var result = BusinessWorkersBL.GetBusinessWorkersByBusinessId(businessId);
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessworkersVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertBusinessPremises(BusinessWorkersVM businessworkersVM)
        {
            var result = BusinessWorkersBL.InsertBusinessPremises(businessworkersVM);
            if (result != null) return Ok(result);
            else return BadRequest();
        }


    }
}
