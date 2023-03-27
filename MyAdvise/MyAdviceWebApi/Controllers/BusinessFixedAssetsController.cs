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
    public class BusinessFixedAssetsController : ControllerBase
    {
        private IBusinessFixedAssetsBL BusinessFixedAssetsBL;

        public BusinessFixedAssetsController(IBusinessFixedAssetsBL businessFixedAssetsBL)
        {
            BusinessFixedAssetsBL = businessFixedAssetsBL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("businessId")]
        public IEnumerable<BusinessFixedAssetsVM> GetBusinessFixedAssetsByBusinessId(int businessId)
        {
            var result = BusinessFixedAssetsBL.GetBusinessFixedAssetsByBusinessId(businessId);
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessFixedAssetsVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertBusinessFixedAssets(BusinessFixedAssetsVM businessFixedAssetsVM)
        {
            var result = BusinessFixedAssetsBL.InsertBusinessFixedAssets(businessFixedAssetsVM);
            if (result != null) return Ok(result);
            else return BadRequest();
        }


    }
}
