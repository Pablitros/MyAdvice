using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models.Models
{
    public class Workers
    {
        public Workers()
        {
            BusinessWorkers = new List<BusinessWorkers>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkersId { get; set; }
        public  string Name{ get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContractType { get; set; }
        public float WorkerPrice { get; set; }
        public float SocialInsurance { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual IEnumerable<BusinessWorkers> BusinessWorkers { get; set; }
    }
}
