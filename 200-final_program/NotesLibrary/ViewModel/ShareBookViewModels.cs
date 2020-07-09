using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModel
{
    public class ShareInfo
    {
        public int Index { get; set; }
        public string ShareLink { get; set; }
        public string HasImplemented { get; set; }
        public string ImplementName { get; set; }
    }
    public class ShareBookViewModel
    {
        public bool HasLogin { get; set; }
        public bool HasBook { get; set; }
        public string BookName { get; set; }
        public IEnumerable<ShareInfo> ShareInfoes { get; set; }
        public int BookId { get; set; }
        public int NoteId { get; set; }

    }
    public class CreateShareViewModel
    {
        public bool HasLogin { get; set; }
        public bool HasBook { get; set; }
        public string BookName { get; set; }
        public string NewShareLink { get; set; }
        public int BookId { get; set; }
        public int NoteId { get; set; }
    }
    public class ShareInfoViewModel
    {
        public bool HasLogin { get; set; }
        public bool CurrectLink { get; set; }
        public bool NotUsed { get; set; }
        public bool NotHasBook { get; set; }
        public string BookName { get; set; }
        public string OwnerName { get; set; }
        
    }
}