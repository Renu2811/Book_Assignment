using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDetails.Entities
{
   
        public class Book
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public int BookId { get; set; }
            [Required]
            [MaxLength(15, ErrorMessage = "Name Should not be more than 15 char")]
            public string BookName { get; set; }
            [Required]
            [MaxLength(15, ErrorMessage = "Zoner Should not be more than 15 char")]
            public string BookZoner { get; set; }
            [Required]
            [DataType(DataType.Date)]
            public DateTime RelaseDate { get; set; }
            [Required]
            public double Cost { get; set; }
           
            [Display(Name = "Image")]
            public string BookImage { get; set; }

        }
    
}
