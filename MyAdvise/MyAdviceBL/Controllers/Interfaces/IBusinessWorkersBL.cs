using DataAccessLayer.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdviceBL.Controllers.Interfaces
{
    public interface IBusinessWorkersBL
    {
        IEnumerable<BusinessWorkersVM> GetBusinessWorkersByBusinessId(int businessId);
        BusinessWorkersVM InsertBusinessPremises(BusinessWorkersVM businessworkersVM);
    }
}
