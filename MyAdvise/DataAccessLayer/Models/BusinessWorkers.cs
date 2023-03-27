using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models.Models
{
    public class BusinessWorkers
    {
        [Key]
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        [Key]
        public int WorkersId { get; set; }
        [ForeignKey("WorkersId")]
        public Workers Workers { get; set; }
    }
}
