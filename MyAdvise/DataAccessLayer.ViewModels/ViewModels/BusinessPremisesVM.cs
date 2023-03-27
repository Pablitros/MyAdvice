using DataAccessLayer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ViewModels.ViewModels
{
    public class BusinessPremisesVM
    {
        public int BusinessId { get; set; }
        public virtual BusinessVM Business { get; set; }
        public int PremisesId { get; set; }
        public virtual PremisesVM Premises { get; set; }

        public BusinessPremisesVM(BusinessPremises businessPremises)
        {
            BusinessId = businessPremises.BusinessId;
            if(businessPremises.Business != null)
            {
                Business = new BusinessVM(businessPremises.Business);
            }
            PremisesId = businessPremises.PremisesId;
            if (businessPremises.Premises != null)
            {
                Premises = new PremisesVM(businessPremises.Premises);
            }
        }
        public BusinessPremisesVM() { }
    }
}
