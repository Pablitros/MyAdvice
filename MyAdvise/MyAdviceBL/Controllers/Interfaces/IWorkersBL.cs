using DataAccessLayer.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdviceBL.Controllers.Interfaces
{
    public interface IWorkersBL
    {
        IEnumerable<WorkersVM> GetWorkers();
        IEnumerable<WorkersVM> GetWorkersByUserId(int userId);
        WorkersVM GetWorkersByWorkersId(int workersId);
        WorkersVM InsertWorkers(WorkersVM workersVM);
        WorkersVM UpdateWorkers(WorkersVM workersVM);
        IEnumerable<WorkersVM> GetAllWorkersNotInNM(int businessId, int userId);
    }
}
