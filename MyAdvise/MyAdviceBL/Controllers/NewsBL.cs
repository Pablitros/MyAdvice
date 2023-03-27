using DataAccessLayer;
using DataAccessLayer.Models.Models;
using DataAccessLayer.ViewModels.ViewModels;
using MyAdviceBL.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdviceBL.Controllers
{
    public class NewsBL : INewsBL
    {
        private readonly IUnitOfWork uow;

        public NewsBL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public NewsVM InsertNews(NewsVM news)
        {
            try
            {
                News n = new News()
                {
                    Title = news.Title,
                    Description = news.Description,
                    Url = news.Url
                };

                if (news != null)
                {
                    uow.News.Insert(n);
                    uow.Commit();
                    return new NewsVM(n);
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
