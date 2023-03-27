using DataAccessLayer;
using DataAccessLayer.Models.Models;
using DataAccessLayer.ViewModels.ViewModels;
using MyAdviceBL.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAdviceBL.Controllers
{
    public class WorkersBL : IWorkersBL
    {
        private readonly IUnitOfWork uow;

        public WorkersBL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<WorkersVM> GetAllWorkersNotInNM(int businessId, int userId)
        {
            string SQL = "Select * from Workers where Workers.WorkersId not in (select WorkersId from BusinessWorkers where BusinessWorkers.BusinessId =" + businessId + ") AND Workers.UserId = " + userId;
            IEnumerable<Workers> workers = uow.Workers.GetBySql(SQL);
            IEnumerable<WorkersVM> workersVM = workers.Select(x => new WorkersVM(x));
            return workersVM;
            //return workersVM;
        }

        public IEnumerable<WorkersVM> GetWorkers()
        {
            var workers = uow.Workers.FindAll(null, x => x.User);
            IEnumerable<WorkersVM> businessVM = workers.Select(x => new WorkersVM(x));
            return businessVM;
        }

        public IEnumerable<WorkersVM> GetWorkersByUserId(int userId)
        {
            var workers = uow.Workers.FindAll(x => x.UserId == userId, x => x.User);
            IEnumerable<WorkersVM> businessVM = workers.Select(x => new WorkersVM(x));
            return businessVM;
        }

        public WorkersVM GetWorkersByWorkersId(int workersId)
        {
            var workers = uow.Workers.FindAll(x => x.WorkersId == workersId, x => x.User);
            WorkersVM businessVM = workers.Select(x => new WorkersVM(x)).FirstOrDefault();
            return businessVM;
        }

        public WorkersVM InsertWorkers(WorkersVM workersVM)
        {
            try
            {
                Workers workers = new Workers()
                {
                    Name = workersVM.Name,
                    Surname = workersVM.Surname,
                    Email = workersVM.Email,
                    ContractType = workersVM.ContractType,
                    WorkerPrice = workersVM.WorkerPrice,
                    SocialInsurance = workersVM.SocialInsurance,
                    UserId = workersVM.UserId
                };

                if (workersVM != null)
                {
                    uow.Workers.Insert(workers);
                    uow.Commit();
                    return new WorkersVM(workers);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error ocurred" + ex);

            }
        }

        public WorkersVM UpdateWorkers(WorkersVM workersVM)
        {
            try
            {
                if (uow.Workers.FindAll(x => x.WorkersId == workersVM.WorkersId) != null)
                {
                    Workers workers = new Workers()
                    {
                        WorkersId = workersVM.WorkersId,
                        Name = workersVM.Name,
                        Surname = workersVM.Surname,
                        Email = workersVM.Email,
                        ContractType = workersVM.ContractType,
                        WorkerPrice = workersVM.WorkerPrice,
                        SocialInsurance = workersVM.SocialInsurance,
                        UserId = workersVM.UserId
                    };

                    uow.Workers.Update(workers);
                    uow.Commit();
                    return new WorkersVM(workers);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error ocurred" + ex);
            }
        }
    }
}
