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
    public class FixedAssetsController : ControllerBase
    {
        private readonly IFixedAssetsBL FixedAssetsBL;

        public FixedAssetsController(IFixedAssetsBL fixedAssetsBL)
        {
            FixedAssetsBL = fixedAssetsBL;
        }

        /// <summary>
        /// Gets all the records on the dataasbe
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<FixedAssetsVM> GetFixedAssets()
        {
            var result = FixedAssetsBL.GetFixedAssets();
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// Gets all the records from FixedAssets by its UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("userId")]
        public IEnumerable<FixedAssetsVM> GetFixedAssetsByUserId(int userId)
        {
            var result = FixedAssetsBL.GetFixedAssetsByUserId(userId);
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetsId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("assetsId")]
        public FixedAssetsVM GetFixedAssetsByFixedAssetsId(int assetsId)
        {
            var result = FixedAssetsBL.GetFixedAssetsByFixedAssetsId(assetsId);
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// Inserts a new FixedAssets record on the database 
        /// </summary>
        /// <param name="fixedAssetsVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertFixedAssets(FixedAssetsVM fixedAssetsVM)
        {
            var result = FixedAssetsBL.InsertFixedAssets(fixedAssetsVM);
            if (result != null) return Ok(result);
            else return BadRequest();

        }

        /// <summary>
        /// Updates the Fixed Assets by its Id
        /// </summary>
        /// <param name="fixedAssetsVM"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateFixedAssets(FixedAssetsVM fixedAssetsVM)
        {
            var result = FixedAssetsBL.UpdateFixedAssets(fixedAssetsVM);
            if (result != null) return Ok(result);
            else return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("business")]
        public IEnumerable<FixedAssetsVM> GetAllFixedAssetsNotInNM(int businessId, int userId)
        {
            var result = FixedAssetsBL.GetAllFixedAssetsNotInNM(businessId, userId);
            if (result != null) return result;
            else return null;
        }
    }
}
