using Microsoft.AspNet.Identity;
using NotesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NotesLibrary.Controllers
{
    public class BookshelfController : Controller
    {
        // GET: Bookshelf
        public ActionResult Index()
        {
            using (LibraryDBContext db = new LibraryDBContext())
            {
                string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                var user = db.Users.Find(UserId);
                if (user == null)
                    return View(new BasicBookViewModel { HasLogin = false });
                string[] books = user.Books.Split(',');
                string[] notes = user.Notes.Split(',');
                var basicBooks = new List<BasicBookInfo>();
                for (int i = 0; i < books.Length; i++)
                {
                    int BookId = Int32.Parse(books[i]);
                    int NoteId = Int32.Parse(notes[i]);
                    BookInfo book = db.BookInfoes.Find(BookId);
                    basicBooks.Add(new BasicBookInfo
                    {
                        BookId = BookId,
                        NoteId = NoteId,
                        BookName = book.Name,
                        Rank = (book.TotalRank * 10 / book.RankPeople / 10.0).ToString(),
                        ReadPeople = book.ReadPeople
                    });
                }
                return View(new BasicBookViewModel
                {
                    HasLogin = true,
                    BasicBooks = basicBooks,
                    TotalBook = books.Length
                });
            }
        }
        public ActionResult Add(int BookId)
        {
            using (LibraryDBContext db = new LibraryDBContext())
            {
                string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                var user = db.Users.Find(UserId);
                if (user != null)
                {
                    int MaxNotetId = db.NoteInfoes.Max(p => p.Id);
                    db.NoteInfoes.Add(new NoteInfo
                    {
                        BookId = BookId,
                        OwnerId = UserId,
                        Id = MaxNotetId + 1
                    });
                    db.SaveChanges();

                    var noteInfo = db.NoteInfoes.Find(BookId, UserId);
                    string bookIdStr = BookId.ToString();
                    string noteIdStr = noteInfo.Id.ToString();
                    if (user.Books != "")
                    {
                        user.Books += ",";
                        user.Notes += ",";
                    }
                    user.Books += bookIdStr;
                    user.Notes += noteIdStr;
                    db.Users.AddOrUpdate(user);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}