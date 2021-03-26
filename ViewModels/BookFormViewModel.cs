using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Raven.Models
{
    public class BookFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Book Book { get; set; }
    }
}