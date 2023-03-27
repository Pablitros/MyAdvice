using DataAccessLayer.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DataAccessLayer.ViewModels.ViewModels
{
    public class FixedAssetsVM
    {
        public int AssetsId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public float AssetsPrice { get; set; }
        public DateTime RegisterDate { get; set; }
        public int UserId { get; set; }
        public UserVM User { get; set; }
        public virtual IEnumerable<BusinessFixedAssetsVM> BusinessFixedAssets { get; set; }

        public FixedAssetsVM(FixedAssets f)
        {
            AssetsId = f.AssetsId;
            Name = f.Name;
            Type = f.Type;
            Description = f.Description;
            AssetsPrice = f.AssetsPrice;
            RegisterDate = f.RegisterDate;
            UserId = f.UserId;
            if (f.User != null)
            {
                User = new UserVM(f.User);
            }
        }

        public FixedAssetsVM() { }
    }
}
