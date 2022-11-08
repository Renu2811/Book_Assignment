using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDetails.Entities
{
    public class AddCart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Name Should not be more than 15 char")]
        public string? BookName { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Zoner Should not be more than 15 char")]
        public string? BookZoner { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }
        public int Cost { get; set; }
        [Display(Name = "image")]
        public string? BookImage { get; set; }
    }
}
