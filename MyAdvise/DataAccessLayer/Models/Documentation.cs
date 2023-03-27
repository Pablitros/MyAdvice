using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models.Models
{
    public class Documentation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentationId { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public bool DocumentationCheck { get; set; }
        [Required]
        [MaxLength(800)]
        public string DescriptionA { get; set; }
        [Required]
        [MaxLength(800)]
        public string DescriptionB { get; set; }
        [Required]
        [MaxLength(300)]
        public string Link { get; set; }
        [MaxLength(300)]
        public string LinkB { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        // To get the relation between the User and the Documentation
        //public ICollection<Documentation> Documentations { get; set; }
    }
}
