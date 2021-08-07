﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wizlib_Model.Models
{
    public class BookDetail
    {
        [Key]
        public int BookDetail_Id { get; set; }

        [Required]
        public int NumberOfChapters { get; set; }
        public int NumberOfPages { get; set; } 
        public double Weight { get; set; }

        public Book Book { get; set; }

    }
}
