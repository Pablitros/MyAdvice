using DataAccessLayer.Models;
using DataAccessLayer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IUnitOfWork
    {
        IRepository<User> User { get; }
        IRepository<Documentation> Documentation { get; }
        IRepository<Business> Business { get; }
        IRepository<BusinessFixedAssets> BusinessFixedAssets { get; }
        IRepository<BusinessPremises> BusinessPremises { get; }
        IRepository<BusinessWorkers> BusinessWorkers { get; }
        IRepository<FixedAssets> FixedAssets { get; }
        IRepository<Premises> Premises { get; }
        IRepository<Workers> Workers { get; }
        IRepository<News> News { get; }






        void Commit();
    }
}
