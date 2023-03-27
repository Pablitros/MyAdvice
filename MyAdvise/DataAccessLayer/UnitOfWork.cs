using DataAccessLayer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DatabaseContext context;

        private Repository<User> users;
        private Repository<Documentation> documentation;
        private Repository<Premises> premises;
        private Repository<Business> business;
        private Repository<BusinessFixedAssets> businessFixedAssets;
        private Repository<BusinessPremises> businessPremises;
        private Repository<BusinessWorkers> businessWorkers;
        private Repository<FixedAssets> fixedAssets;
        private Repository<Workers> workers;
        private Repository<News> news;

        public UnitOfWork(DatabaseContext context)
        {
            this.context = context;
        }

        public IRepository<User> User => users ?? (users = new Repository<User>(context));
        public IRepository<Documentation> Documentation => documentation ?? (documentation = new Repository<Documentation>(context));
        public IRepository<Premises> Premises => premises ?? (premises = new Repository<Premises>(context));
        public IRepository<Business> Business => business ?? (business = new Repository<Business>(context));

        public IRepository<BusinessFixedAssets> BusinessFixedAssets => businessFixedAssets ?? (businessFixedAssets = new Repository<BusinessFixedAssets>(context));

        public IRepository<FixedAssets> FixedAssets => fixedAssets ?? (fixedAssets = new Repository<FixedAssets>(context));

        public IRepository<Workers> Workers => workers ?? (workers = new Repository<Workers>(context));

        public IRepository<BusinessPremises> BusinessPremises => businessPremises ?? (businessPremises = new Repository<BusinessPremises>(context));

        public IRepository<BusinessWorkers> BusinessWorkers => businessWorkers ?? (businessWorkers = new Repository<BusinessWorkers>(context));
        public IRepository<News> News => news ?? (news = new Repository<News>(context));

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
