using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_Raven.Models
{
    public class BookFormViewModel
    {
        public BookFormViewModel()
        {
            Id = 0;
        }
        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            PublisheDate = book.PublisheDate;
            NumberInStock = book.NumberInStock;
            GenreId = book.GenreId;
        }

        public IEnumerable<Genre> Genres { get; set; }
        [Required]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Book name is required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Publishe Date")]
        public DateTime? PublisheDate { get; set; }


        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }

        }
    }
}