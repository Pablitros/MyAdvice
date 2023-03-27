using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models.Models
{
    public class BusinessFixedAssets
    {
        [Key]
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        [Key]
        public int FixedAssetsId { get; set; }
        [ForeignKey("FixedAssetsId")]
        public FixedAssets FixedAssets { get; set; }
    }
}
