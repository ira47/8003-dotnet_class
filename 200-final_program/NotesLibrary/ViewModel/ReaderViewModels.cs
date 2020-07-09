using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModel
{
    public class ReaderViewModel
    {
        public bool HasLogin { get; set; }
        public bool HasChooseBook { get; set; }
        public IEnumerable<BookLine> BookLines { get; set; }
        public IEnumerable<NoteLine> Notes { get; set; }
        public int TotalNotes { get; set; }
        public string BookName { get; set; }
        public string OwnerName { get; set; }
        public string CopyrightName { get; set; }
        public int StartLine { get; set; }
        public int EndLine { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
        public int LinePerPage { get; set; }
        // 承载页面输入的变量
        public int? GotoPage { get; set; }
        public int? NoteIndex { get; set; }
        public string Note { get; set; }
    }
}