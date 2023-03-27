using DataAccessLayer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ViewModels.ViewModels
{
    public class BusinessFixedAssetsVM
    {
        public int BusinessId { get; set; }
        public BusinessVM Business { get; set; }
        public int FixedAssetsId { get; set; }
        public FixedAssetsVM FixedAssets { get; set; }

        public BusinessFixedAssetsVM(BusinessFixedAssets b)
        {
            BusinessId = b.BusinessId;
            if (b.Business != null)
            {
                Business = new BusinessVM(b.Business);
            }
            FixedAssetsId = b.FixedAssetsId;
            if (b.FixedAssets != null)
            {
                FixedAssets = new FixedAssetsVM(b.FixedAssets);
            }
        }
        public BusinessFixedAssetsVM() { }
    }
}
