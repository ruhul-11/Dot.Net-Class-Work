using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Models
{
    public class Borrow
    {
        [Key]
        public int BorrowId { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        [Remote("IsMemberExists", "Member", ErrorMessage = "Sorry, Member already exists.")]
        public virtual Member Member { get; set; }

        public bool IsBorrowed { get; set; }
    }
}