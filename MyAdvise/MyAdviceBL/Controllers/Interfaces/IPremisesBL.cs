using DataAccessLayer.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdviceBL.Controllers.Interfaces
{
    public interface IPremisesBL
    {
        IEnumerable<PremisesVM> GetPremises();
        IEnumerable<PremisesVM> GetPremisesByUserId(int userId);
        PremisesVM GetPremisesByPremisesId(int premisesId);
        PremisesVM InsertPremises(PremisesVM premisesVM);
        PremisesVM UpdatePremises(PremisesVM premisesVM);
        IEnumerable<PremisesVM> GetAllPremisesNotInNM(int businessId, int userId);
    }
}
