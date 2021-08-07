using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using Wizlib_Model.Models;

namespace Wizlib_Model.ViewModels
{
    public class BookAuthorVM
    {
        public BookAuthor BookAuthor { get; set; }
        public Book Book { get; set; }
        public IEnumerable<BookAuthor> BookAuthorList { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
    }
}
