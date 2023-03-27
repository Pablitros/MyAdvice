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
    public class BusinessBL : IBusinessBL
    {
        private readonly IUnitOfWork uow;
        public BusinessBL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<BusinessVM> GetBusiness()
        {
            var business = uow.Business.FindAll();
            var businessVM = business.Select(x => new BusinessVM(x));
            return businessVM;
        }

        public BusinessVM GetBusinessByBusinessId(int businessId)
        {
            var business = uow.Business.FindAll(x => x.BusinessId == businessId, x => x.User);
            BusinessVM businessVM = business.Select(x => new BusinessVM(x)).First();
            return businessVM;
        }

        public IEnumerable<BusinessVM> GetBusinessByUserId(int userId)
        {
            var business = uow.Business.FindAll(x => x.UserId == userId, x => x.User);
            IEnumerable<BusinessVM> businessVM = business.Select(x => new BusinessVM(x));
            return businessVM;
        }

        public BusinessVM InsertBusiness(BusinessVM businessVM)
        {
            try
            {
                Business business = new Business()
                {
                    BusinessId = businessVM.BusinessId,
                    Name = businessVM.Name,
                    Address = businessVM.Address,
                    BusinessRegisterDate = DateTime.Now,
                    Activity = businessVM.Activity,
                    Description = businessVM.Description,
                    UserId = businessVM.UserId
                };

                if (businessVM != null)
                {
                    uow.Business.Insert(business);
                    uow.Commit();
                    return new BusinessVM(business);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error ocurred" + ex);

            }
        }

        public BusinessVM UpdateBusiness(BusinessVM businessVM)
        {
            try
            {
                if (uow.Business.FindAll(x => x.BusinessId == businessVM.BusinessId) != null)
                {
                    Business business = new Business()
                    {
                        BusinessId = businessVM.BusinessId,
                        Name = businessVM.Name,
                        Address = businessVM.Address,
                        Activity = businessVM.Activity,
                        Description = businessVM.Description,
                        UserId = businessVM.UserId
                    };

                    uow.Business.Update(business);
                    uow.Commit();
                    return new BusinessVM(business);
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
