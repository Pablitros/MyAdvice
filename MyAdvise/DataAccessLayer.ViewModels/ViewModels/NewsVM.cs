using DataAccessLayer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ViewModels.ViewModels
{
    public class NewsVM
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public NewsVM() { }
        public NewsVM(News n)
        {
            NewsId = n.NewsId;
            Title = n.Title;
            Description = n.Description;
            Url = n.Url;
        }
    }
}
