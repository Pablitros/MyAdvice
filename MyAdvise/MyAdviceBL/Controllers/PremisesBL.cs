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
    public class PremisesBL : IPremisesBL
    {
        private readonly IUnitOfWork uow;

        public PremisesBL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<PremisesVM> GetAllPremisesNotInNM(int businessId, int userId)
        {
            string SQL = "Select * from Premises where Premises.PremisesId not in (select PremisesId from BusinessPremises where BusinessPremises.BusinessId =" + businessId + ") AND Premises.UserId = " + userId;
            IEnumerable<Premises> premises = uow.Premises.GetBySql(SQL);
            IEnumerable<PremisesVM> premisesVM = premises.Select(x => new PremisesVM(x));
            return premisesVM;
        }

        public IEnumerable<PremisesVM> GetPremises()
        {
            var premises = uow.Premises.FindAll(null, x => x.User);
            IEnumerable<PremisesVM> premisesVM = premises.Select(x => new PremisesVM(x));
            return premisesVM;
        }

        public PremisesVM GetPremisesByPremisesId(int premisesId)
        {
            var premises = uow.Premises.FindAll(x => x.PremisesId == premisesId, x => x.User);
            PremisesVM premisesVM = premises.Select(x => new PremisesVM(x)).FirstOrDefault();
            return premisesVM;
        }

        public IEnumerable<PremisesVM> GetPremisesByUserId(int userId)
        {
            var premises = uow.Premises.FindAll(x => x.UserId == userId, x => x.User);
            var premisesVM = premises.Select(x => new PremisesVM(x));
            return premisesVM;
        }

        public PremisesVM InsertPremises(PremisesVM premisesVM)
        {
            try
            {
                if (premisesVM != null)
                {
                    Premises premises = new Premises()
                    {
                        Address = premisesVM.Address,
                        Description = premisesVM.Description,
                        Price = premisesVM.Price,
                        UserId = premisesVM.UserId
                    };

                    uow.Premises.Insert(premises);
                    uow.Commit();
                    return new PremisesVM(premises);
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error ocurred" + ex);
            }
        }

        public PremisesVM UpdatePremises(PremisesVM premisesVM)
        {
            try
            {
                if (uow.Premises.FindAll(x => x.PremisesId == premisesVM.PremisesId) != null)
                {
                    Premises premises = new Premises()
                    {
                        PremisesId = premisesVM.PremisesId,
                        Address = premisesVM.Address,
                        Description = premisesVM.Description,
                        Price = premisesVM.Price,
                        UserId = premisesVM.UserId
                    };

                    uow.Premises.Update(premises);
                    uow.Commit();
                    return new PremisesVM(premises);
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
