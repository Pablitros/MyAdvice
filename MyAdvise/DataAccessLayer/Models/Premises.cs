using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models.Models
{
    public class Premises
    {
        public Premises()
        {
            BusinessPremises = new List<BusinessPremises>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PremisesId { get; set; }
        [MaxLength(200)]
        [Required]
        public string Address { get; set; }
        [MaxLength(200)]
        [Required]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual IEnumerable<BusinessPremises> BusinessPremises { get; set; }
    }
}
