using DataAccessLayer;
using DataAccessLayer.Models.Models;
using DataAccessLayer.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace MyAdviceBL.Controllers.Interfaces
{
    public class BusinessPremisesBL : IBusinessPremisesBL
    {
        private readonly IUnitOfWork uow;

        public BusinessPremisesBL(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public IEnumerable<BusinessPremisesVM> GetBusinessPremisesByBusinessId(int businessId)
        {
            var businessPremises = uow.BusinessPremises.FindAll(x => x.BusinessId == businessId, x => x.Premises);
            IEnumerable<BusinessPremisesVM> businessPremisesVM = businessPremises.Select(x => new BusinessPremisesVM(x));
            return businessPremisesVM;
        }

        public BusinessPremisesVM InsertBusinessPremises(BusinessPremisesVM businessPremisesVM)
        {
            try
            {
                BusinessPremises businessPremises = new BusinessPremises()
                {
                    BusinessId = businessPremisesVM.BusinessId,
                    PremisesId = businessPremisesVM.PremisesId
                };

                if (businessPremisesVM != null)
                {
                    uow.BusinessPremises.Insert(businessPremises);
                    uow.Commit();
                    return new BusinessPremisesVM(businessPremises);
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
