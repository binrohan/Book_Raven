using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_Raven.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name="Publishe Date")]
        public DateTime PublisheDate { get; set; }

        
        public DateTime AddedDate { get; set; }

        [Required]
        [Display(Name="Number in Stock")]
        public int NumberInStock { get; set; }
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }
    }
}