using DataAccessLayer.Models.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DataAccessLayer.ViewModels.ViewModels
{
    public class PremisesVM
    {
        public int PremisesId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int UserId { get; set; }
        public UserVM User { get; set; }

        public PremisesVM(Premises p)
        {
            PremisesId = p.PremisesId;
            Address = p.Address;
            Description = p.Description;
            Price = p.Price;
            UserId = p.UserId;
            
        }
        public PremisesVM() { }

    }
}
