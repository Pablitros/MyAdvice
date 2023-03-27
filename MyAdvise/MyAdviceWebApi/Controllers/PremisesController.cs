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
    public class PremisesController : ControllerBase
    {
        private readonly IPremisesBL PremisesBL;

        public PremisesController(IPremisesBL premisesBL)
        {
            PremisesBL = premisesBL;
        }

        /// <summary>
        /// Gets all the Premises
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<PremisesVM> GetPremises()
        {
            var result = PremisesBL.GetPremises();
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("userId")]
        public IEnumerable<PremisesVM> GetPremisesByUserId(int userId)
        {
            var result = PremisesBL.GetPremisesByUserId(userId);
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="premisesId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("premisesId")]
        public PremisesVM GetPremisesByPremisesId(int premisesId)
        {
            var result = PremisesBL.GetPremisesByPremisesId(premisesId);
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// Creates a new Premises on the database
        /// </summary>
        /// <param name="premisesVM"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IActionResult InsertPremises(PremisesVM premisesVM)
        {
            var result = PremisesBL.InsertPremises(premisesVM);
            if (result != null) return Ok(result);
            else return BadRequest();

        }

        /// <summary>
        /// Updates the premises depending on the User
        /// </summary>
        /// <param name="premisesVM"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdatePremises(PremisesVM premisesVM)
        {
            var result = PremisesBL.UpdatePremises(premisesVM);
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
        public IEnumerable<PremisesVM> GetAllPremisesNotInNM(int businessId, int userId)
        {
            var result = PremisesBL.GetAllPremisesNotInNM(businessId, userId);
            if (result != null) return result;
            else return null;
        }

    }
}
