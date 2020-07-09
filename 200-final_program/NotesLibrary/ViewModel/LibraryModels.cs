using System;

namespace ViewModel
{
    public class BookInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string OwnerId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int TotalRank { get; set; }
        public int RankPeople { get; set; }
        public int ReadPeople { get; set; }
        public int TotalLine { get; set; }
    }

    public class BookLine
    {
        public int ContentId { get; set; }
        public int LineIndex { get; set; }
        public string Line { get; set; }
    }

    public class NoteLine
    {
        public int NoteId { get; set; }
        public int LineIndex { get; set; }
        public string UserName { get; set; }
        public string Note { get; set; }

        public static explicit operator NoteLine(global::NotesLibrary.Models.NoteLine v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator NoteLine(global::NotesLibrary.Models.NoteLine v)
        {
            throw new NotImplementedException();
        }
    }

    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Books { get; set; }
        public string Notes { get; set; }
        public int LastBook { get; set; }
        public int LastNote { get; set; }
        public int LastLine { get; set; }
    }
    public class NoteInfo
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string OwnerId { get; set; }
    }

    public class ShareLine
    {
        public string VerifyCode { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public string ImplementId { get; set; }
    }
}