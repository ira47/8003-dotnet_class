using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotesLibrary.Models
{
    public class NoteViewModel
    {
        public int Index { get; set; }
        public int LineIndex { get; set; }
        public string Note { get; set; }
    }
    public class ReaderViewModel
    {
        public IEnumerable<BookLine> BookLines { get; set; }
        public IEnumerable<NoteViewModel> Notes { get; set; }
        public int? NoteIndex { get; set; }
        public string Note { get; set; }

    }
}