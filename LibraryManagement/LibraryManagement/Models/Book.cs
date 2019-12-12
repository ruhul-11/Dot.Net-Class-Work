using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "please enter Title")]
        [Remote("IsTitleExists", "Book", ErrorMessage = "Sorry, Book already exists")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "please enter Author")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "please enter Publisher")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }
    }
}