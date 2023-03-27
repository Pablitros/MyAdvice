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
using System.Security.Cryptography.X509Certificates;
using MyAdviceBL.Controllers.Interfaces;

namespace MyAdviceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessPremisesController : ControllerBase
    {
        private IBusinessPremisesBL BusinessPremisesBL;

        public BusinessPremisesController(IBusinessPremisesBL businessPremisesBL)
        {
            BusinessPremisesBL = businessPremisesBL;
        }

        /// <summary>
        /// Selects the user thats related to the n - m table
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("businessId")]
        public IEnumerable<BusinessPremisesVM> GetBusinessPremisesByBusinessId(int businessId)
        {
            var result = BusinessPremisesBL.GetBusinessPremisesByBusinessId(businessId);
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// Creates a record on the table BusinessPremises
        /// </summary>
        /// <param name="businessPremisesVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertBusinessPremises(BusinessPremisesVM businessPremisesVM)
        {
            var result = BusinessPremisesBL.InsertBusinessPremises(businessPremisesVM);
            if (result != null) return Ok(result);
            else return BadRequest();
        }


    }
}
