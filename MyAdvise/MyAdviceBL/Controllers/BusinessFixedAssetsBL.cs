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
    public class BusinessFixedAssetsBL : IBusinessFixedAssetsBL
    {
        private IUnitOfWork uow;

        public BusinessFixedAssetsBL(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public IEnumerable<BusinessFixedAssetsVM> GetBusinessFixedAssetsByBusinessId(int businessId)
        {
            var businessFixedAssets = uow.BusinessFixedAssets.FindAll(x => x.BusinessId  == businessId, x => x.FixedAssets);
            IEnumerable<BusinessFixedAssetsVM> businessFixedAssetsVM = businessFixedAssets.Select(x => new BusinessFixedAssetsVM(x));
            return businessFixedAssetsVM;
        }

        public BusinessFixedAssetsVM InsertBusinessFixedAssets(BusinessFixedAssetsVM businessFixedAssetsVM)
        {
            try
            {
                BusinessFixedAssets businessFixedAssets = new BusinessFixedAssets()
                {
                    BusinessId = businessFixedAssetsVM.BusinessId,
                    FixedAssetsId = businessFixedAssetsVM.FixedAssetsId
                };

                if (businessFixedAssetsVM != null)
                {
                    uow.BusinessFixedAssets.Insert(businessFixedAssets);
                    uow.Commit();
                    return new BusinessFixedAssetsVM(businessFixedAssets);
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
