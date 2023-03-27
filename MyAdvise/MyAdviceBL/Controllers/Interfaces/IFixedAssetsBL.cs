using DataAccessLayer.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdviceBL.Controllers.Interfaces
{
    public interface IFixedAssetsBL
    {
        IEnumerable<FixedAssetsVM> GetFixedAssets();
        IEnumerable<FixedAssetsVM> GetFixedAssetsByUserId(int userId);
        FixedAssetsVM GetFixedAssetsByFixedAssetsId(int fixedAssetsId);
        FixedAssetsVM InsertFixedAssets(FixedAssetsVM fixedAssetsVM);
        FixedAssetsVM UpdateFixedAssets(FixedAssetsVM fixedAssetsVM);
        IEnumerable<FixedAssetsVM> GetAllFixedAssetsNotInNM(int businessId, int userId);
    }
}
