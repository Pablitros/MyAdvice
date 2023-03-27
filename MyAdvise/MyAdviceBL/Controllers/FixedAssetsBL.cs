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
    public class FixedAssetsBL : IFixedAssetsBL
    {
        private readonly IUnitOfWork uow;

        public FixedAssetsBL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<FixedAssetsVM> GetFixedAssets()
        {
            var fixedAssets = uow.FixedAssets.FindAll(null, x => x.User);
            IEnumerable<FixedAssetsVM> fixedAssetsVM = fixedAssets.Select(x => new FixedAssetsVM(x));
            return fixedAssetsVM;
        }

        public IEnumerable<FixedAssetsVM> GetFixedAssetsByUserId(int userId)
        {
            var fixedAssets = uow.FixedAssets.FindAll(x => x.UserId == userId, x => x.User);
            IEnumerable<FixedAssetsVM> fixedAssetsVM = fixedAssets.Select(x => new FixedAssetsVM(x));
            return fixedAssetsVM;
        }
        public FixedAssetsVM GetFixedAssetsByFixedAssetsId(int fixedAssetsId)
        {
            var fixedAssets = uow.FixedAssets.FindAll(x => x.AssetsId == fixedAssetsId, x => x.User);
            FixedAssetsVM fixedAssetsVM = fixedAssets.Select(x => new FixedAssetsVM(x)).FirstOrDefault();
            return fixedAssetsVM;
        }

        public FixedAssetsVM InsertFixedAssets(FixedAssetsVM fixedAssetsVM)
        {
            try
            {
                FixedAssets fixedAssets = new FixedAssets()
                {
                    Name = fixedAssetsVM.Name,
                    Type = fixedAssetsVM.Type,
                    Description = fixedAssetsVM.Description,
                    AssetsPrice = fixedAssetsVM.AssetsPrice,
                    RegisterDate = DateTime.Now,
                    UserId = fixedAssetsVM.UserId
                };

                if (fixedAssetsVM != null)
                {
                    uow.FixedAssets.Insert(fixedAssets);
                    uow.Commit();
                    return new FixedAssetsVM(fixedAssets);
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error ocurred" + ex);
            }
        }

        public FixedAssetsVM UpdateFixedAssets(FixedAssetsVM fixedAssetsVM)
        {
            try
            {
                if (uow.FixedAssets.FindAll(x => x.AssetsId == fixedAssetsVM.AssetsId) != null)
                {
                    FixedAssets fixedAssets = new FixedAssets()
                    {
                        AssetsId = fixedAssetsVM.AssetsId,
                        Name = fixedAssetsVM.Name,
                        Type = fixedAssetsVM.Type,
                        Description = fixedAssetsVM.Description,
                        AssetsPrice = fixedAssetsVM.AssetsPrice,
                        UserId = fixedAssetsVM.UserId
                    };

                    uow.FixedAssets.Update(fixedAssets);
                    uow.Commit();
                    return new FixedAssetsVM(fixedAssets);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error ocurred" + ex);
            }
        }

        public IEnumerable<FixedAssetsVM> GetAllFixedAssetsNotInNM(int businessId, int userId)
        {
            string SQL = "Select * from FixedAssets where FixedAssets.AssetsId not in (select FixedAssetsId from BusinessFixedAssets where BusinessFixedAssets.BusinessId = " + businessId + ") AND FixedAssets.UserId =" + userId;
            IEnumerable<FixedAssets> fixedAssets = uow.FixedAssets.GetBySql(SQL);
            IEnumerable<FixedAssetsVM> fixedAssetsVM = fixedAssets.Select(x => new FixedAssetsVM(x));
            return fixedAssetsVM;
        }
    }
}
