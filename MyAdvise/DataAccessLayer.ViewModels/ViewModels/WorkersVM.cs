
using DataAccessLayer.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.ViewModels.ViewModels
{
    public class WorkersVM
    {
        public int WorkersId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContractType { get; set; }
        public float WorkerPrice { get; set; }
        public float SocialInsurance { get; set; }
        public int UserId { get; set; }
        public UserVM User { get; set; }
        public IEnumerable<BusinessWorkersVM> BusinessWorkers { get; set; }

        public WorkersVM() { }

        public WorkersVM(Workers w)
        {
            WorkersId = w.WorkersId;
            Name = w.Name;
            Surname = w.Surname;
            Email = w.Email;
            ContractType = w.ContractType;
            WorkerPrice = w.WorkerPrice;
            SocialInsurance = w.SocialInsurance;
            UserId = w.UserId;
            if (w.User != null)
            {
                User = new UserVM(w.User);
            }
        }

    }
}
