using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models.Models
{
    public class BusinessPremises
    {
        [Key]
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public virtual Business Business { get; set; }
        [Key]
        public int PremisesId { get; set; }
        [ForeignKey("PremisesId")]
        public virtual Premises Premises { get; set; }
    }
}
