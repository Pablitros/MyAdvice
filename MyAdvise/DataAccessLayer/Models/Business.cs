using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models.Models
{
    public class Business
    {
        public Business()
        {
            BusinessPremises = new List<BusinessPremises>();
            BusinessFixedAssets = new List<BusinessFixedAssets>();
            BusinessWorkers = new List<BusinessWorkers>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BusinessId { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        public DateTime BusinessRegisterDate { get; set; }
        [MaxLength(50)]
        public string Activity { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual List<Documentation> Documentation { get; set; }
        public virtual List<BusinessPremises> BusinessPremises { get; set; }
        public virtual List<BusinessFixedAssets> BusinessFixedAssets { get; set; }
        public virtual List<BusinessWorkers> BusinessWorkers { get; set; }
        
    }
}
