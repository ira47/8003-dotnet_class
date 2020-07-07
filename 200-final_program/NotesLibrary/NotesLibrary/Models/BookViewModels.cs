using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace NotesLibrary.Models
{
    public class BasicBookInfo
    {
        public int BookId { get; set; }
        public int? NoteId { get; set; }
        public string BookName { get; set; }
        public string Rank { get; set; }
        public int ReadPeople { get; set; }
    }
    public class BasicBookViewModel
    {
        public bool HasLogin { get; set; }
        public IEnumerable<BasicBookInfo> BasicBooks { get; set; }
        public int TotalBook { get; set; }
    }
    public class DetailBookViewModel
    {
        public int BookId { get; set; }
        public int? NoteId { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string OwnerName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Rank { get; set; }
        public int RankPeople { get; set; }
        public int TotalLine { get; set; }
        public int MyRank { get; set; }
    }
    public class AddBookViewModel
    {
        [Required]
        [Display(Name = "书名")]
        public string Name { get; set; }

        [Display(Name = "ISBN编号")]
        public string ISBN { get; set; }

        [Display(Name = "作者")]
        public string Author { get; set; }

        [Display(Name = "种类(以英文逗号隔开)")]
        public string Category { get; set; }

        [Display(Name = "书籍简述")]
        public string Description { get; set; }

        [Display(Name = "是否为私有书籍")]
        public bool IsPrivate { get; set; }
        
        [Display(Name = "选择文件")]
        public string TextPath { get; set; }

        public HttpPostedFileBase TextFile { get; set; }

    }
}