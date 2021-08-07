using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text;
using Wizlib_Model.Models;

namespace Wizlib_Model.ViewModels
{
    public class BookPublisherVM
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> Publishers { get; set; }        
    }
}
