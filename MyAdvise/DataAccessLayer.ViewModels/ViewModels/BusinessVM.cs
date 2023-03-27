using DataAccessLayer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ViewModels.ViewModels
{
    public class BusinessVM
    {
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BusinessRegisterDate { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public virtual UserVM User { get; set; }

        public BusinessVM(Business b)
        {
            BusinessId = b.BusinessId;
            Name = b.Name;
            Address = b.Address;
            BusinessRegisterDate = b.BusinessRegisterDate;
            UserId = b.UserId;
            if (b.User != null)
            {
                User = new UserVM(b.User);
            }
            Activity = b.Activity;
            Description = b.Description;
        }
        public BusinessVM() { }
    }
}
