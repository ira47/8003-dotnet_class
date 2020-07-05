using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesLibrary.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public bool IsPrivate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
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
        public int ContentId { get; set; }
        [Key, Column(Order = 1)]
        public int LineIndex { get; set; }
        public string Note { get; set; }
    }

    public class LibraryDBContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }
        public DbSet<BookLine> Books { get; set; }
        public DbSet<NoteLine> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>().ToTable("Contents");
            modelBuilder.Entity<BookLine>().ToTable("Books");
            modelBuilder.Entity<NoteLine>().ToTable("Notes");
            base.OnModelCreating(modelBuilder);
        }
    }
}