using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required(ErrorMessage = "please enter Member Number")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Member Number")]
        [Remote("IsMemberExists", "Member", ErrorMessage = "Sorry, Member already exists.")]
        public string MemberNo { get; set; }

        [Required(ErrorMessage = "please enter Member Name")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Member Name")]
        public string Name { get; set; }
    }
}