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
    public class WorkersController : ControllerBase
    {
        private IWorkersBL WorkersBL;

        public WorkersController(IWorkersBL workersBL)
        {
            WorkersBL = workersBL;
        }


        /// <summary>
        /// Returns all the Workers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WorkersVM> GetWorkers()
        {
            var result = WorkersBL.GetWorkers();
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// Gets all the workers by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("userId")]
        public IEnumerable<WorkersVM> GetWorkersByUserId(int userId)
        {
            var result = WorkersBL.GetWorkersByUserId(userId);
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workersId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("workersId")]
        public WorkersVM GetWorkersByWorkersId(int workersId)
        {
            var result = WorkersBL.GetWorkersByWorkersId(workersId);
            if (result != null) return result;
            else return null;
        }

        /// <summary>
        /// Insertnew Workers on the database
        /// </summary>
        /// <param name="workersVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertWorkers(WorkersVM workersVM)
        {
            var result = WorkersBL.InsertWorkers(workersVM);
            if (result != null) return Ok(result);
            else return BadRequest();
        }

        /// <summary>
        /// Updates its Worker by its UserId
        /// </summary>
        /// <param name="workersVM"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateWorkers(WorkersVM workersVM)
        {
            var result = WorkersBL.UpdateWorkers(workersVM);
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
        public IEnumerable<WorkersVM> GetAllWorkersNotInNM(int businessId, int userId)
        {
            var result = WorkersBL.GetAllWorkersNotInNM(businessId, userId);
            if (result != null) return result;
            else return null;

        }
    }
}
