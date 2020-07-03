using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NotesLibrary.Models
{
    public class AddBasicContentViewModel
    {
        [Required]
        [Display(Name = "书名")]
        public string Name { get; set; }

        [Display(Name = "ISBN编号")]
        public string ISBN { get; set; }

        [Display(Name = "作者")]
        public string Author { get; set; }

        [Display(Name = "书籍简述")]
        public string Description { get; set; }

        [Display(Name = "是否为私有书籍")]
        public bool IsPrivate { get; set; }

    }
}