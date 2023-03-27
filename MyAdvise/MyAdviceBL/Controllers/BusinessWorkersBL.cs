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
    public class BusinessWorkersBL : IBusinessWorkersBL
    {

        private readonly IUnitOfWork uow;

        public BusinessWorkersBL(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public IEnumerable<BusinessWorkersVM> GetBusinessWorkersByBusinessId(int businessId)
        {
            var businessWorkers = uow.BusinessWorkers.FindAll(x => x.BusinessId == businessId, x => x.Workers);
            businessWorkers.ToList();

            IEnumerable<BusinessWorkersVM> businessWorkersVM = businessWorkers.Select(x => new BusinessWorkersVM(x));
            return businessWorkersVM;
        }

        public BusinessWorkersVM InsertBusinessPremises(BusinessWorkersVM businessworkersVM)
        {
            try
            {
                BusinessWorkers businessworkers = new BusinessWorkers()
                {
                    BusinessId = businessworkersVM.BusinessId,
                    WorkersId = businessworkersVM.WorkersId
                };

                if (businessworkersVM != null)
                {
                    uow.BusinessWorkers.Insert(businessworkers);
                    uow.Commit();
                    return new BusinessWorkersVM(businessworkers);
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
