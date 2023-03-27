using DataAccessLayer.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdviceBL.Controllers.Interfaces
{
    public interface INewsBL
    {
        NewsVM InsertNews(NewsVM news);
    }
}
