using DataAccessLayer.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdviceBL.Controllers.Interfaces
{
    public interface IBusinessPremisesBL
    {
        IEnumerable<BusinessPremisesVM> GetBusinessPremisesByBusinessId(int businessId);
        BusinessPremisesVM InsertBusinessPremises(BusinessPremisesVM businessPremisesVM);
    }
}
