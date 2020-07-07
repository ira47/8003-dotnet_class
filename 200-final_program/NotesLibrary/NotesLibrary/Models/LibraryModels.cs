using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Antlr.Runtime.Tree;

namespace NotesLibrary.Models
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
        [Key, Column(Order = 0)]
        public int ContentId { get; set; }
        [Key, Column(Order = 1)]
        public int LineIndex { get; set; }
        public string Line { get; set; }
    }

    public class NoteLine
    {
        [Key, Column(Order = 0)]
        public int NoteId { get; set; }
        [Key, Column(Order = 1)]
        public int LineIndex { get; set; }
        public string UserName { get; set; }
        public string Note { get; set; }
    }

    public class User
    {
        [Key]
        [StringLength(128)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Books { get; set; }
        public string Notes { get; set; }
        public int? LastBook { get; set; }
        public int LastNote { get; set; }
        public int LastLine { get; set; }
    }
    public class LendBook
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        [Key, Column(Order = 1)]
        public int NoteId { get; set; }
        public bool HasLend { get; set; }
    }
    public class NoteInfo
    {
        public int Id { get; set; }
        [Key, Column(Order = 0)]
        public int BookId { get; set; }
        [StringLength(128)]
        [Key, Column(Order = 1)]
        public string OwnerId { get; set; }
    }

    public class LibraryDBContext : DbContext
    {
        public DbSet<BookInfo> BookInfoes { get; set; }
        public DbSet<BookLine> Books { get; set; }
        public DbSet<NoteLine> Notes { get; set; }
        public DbSet<NoteInfo> NoteInfoes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LendBook> LendBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteInfo>().ToTable("NoteInfoes");
            modelBuilder.Entity<BookLine>().ToTable("Books");
            modelBuilder.Entity<NoteLine>().ToTable("Notes");
            modelBuilder.Entity<NoteInfo>().ToTable("NoteInfoes");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<LendBook>().ToTable("LendBooks");
            base.OnModelCreating(modelBuilder);
        }
    }
}