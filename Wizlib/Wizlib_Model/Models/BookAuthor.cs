using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wizlib_Model.Models
{
    public class BookAuthor
    {
        //[Key]
        //public int BookAuthorId { get; set; }
        [ForeignKey("Book")]
        public int Book_Id { get; set; }
        [ForeignKey("Author")]
        public int Author_Id { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
