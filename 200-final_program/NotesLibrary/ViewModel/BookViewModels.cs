using System.Collections.Generic;

namespace ViewModel
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
        public bool HasLogin { get; set; }
    }
    public class AddBookViewModel
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public string TextPath { get; set; }

    }
}