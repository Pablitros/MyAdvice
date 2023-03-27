using DataAccessLayer.Models.Models;
using DataAccessLayer.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels.ViewModels
{
    public class BusinessWorkersVM
    {
        public int BusinessId { get; set; }
        public BusinessVM Business { get; set; }
        public int WorkersId { get; set; }
        public WorkersVM Workers { get; set; }

        public BusinessWorkersVM() { }

        public BusinessWorkersVM(BusinessWorkers b)
        {
            BusinessId = b.BusinessId;
            if (b.Business != null)
            {
                Business = new BusinessVM(b.Business);
            }
            WorkersId = b.WorkersId;
            if (b.Workers != null)
            {
                Workers = new WorkersVM(b.Workers);
            }

        }
    }
}
