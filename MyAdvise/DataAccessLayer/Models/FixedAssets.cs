using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models.Models
{
    public class FixedAssets
    {
        public FixedAssets()
        {
            BusinessFixedAssets = new List<BusinessFixedAssets>();
        }
        [Key]
        public int AssetsId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public float AssetsPrice { get; set; }
        public DateTime RegisterDate { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public virtual IEnumerable<BusinessFixedAssets> BusinessFixedAssets { get; set; }
    }
}
