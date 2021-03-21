using Book_Raven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Raven.ViewModels
{
    public class RamdomBookViewModel
    {
        public Book Book { get; set; }
        public List<Customer> Customers { get; set; }
    }
}