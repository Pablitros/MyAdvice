using DataAccessLayer.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdviceBL.Controllers.Interfaces
{
    public interface IBusinessFixedAssetsBL
    {
        IEnumerable<BusinessFixedAssetsVM> GetBusinessFixedAssetsByBusinessId(int businessId);
        BusinessFixedAssetsVM InsertBusinessFixedAssets(BusinessFixedAssetsVM businessFixedAssetsVM);
    }
}
