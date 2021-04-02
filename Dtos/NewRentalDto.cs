using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Raven.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> BookIds { get; set; }

    }
}