using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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
        public bool HasText { get; set; }
        public string Description { get; set; }
    }

    public class LibraryDBContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>().ToTable("Contents");
            base.OnModelCreating(modelBuilder);
        }
    }
}