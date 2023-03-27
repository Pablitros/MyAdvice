using DataAccessLayer.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdviceBL.Controllers.Interfaces
{
    public interface IBusinessBL
    {
        IEnumerable<BusinessVM> GetBusiness();
        IEnumerable<BusinessVM> GetBusinessByUserId(int userId);
        BusinessVM GetBusinessByBusinessId(int businessId);
        BusinessVM InsertBusiness(BusinessVM businessVM);
        BusinessVM UpdateBusiness(BusinessVM businessVM);
    }
}
