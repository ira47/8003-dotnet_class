using Microsoft.AspNet.Identity;
using NotesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace NotesLibrary.Controllers
{
    public class ReaderController : Controller
    {
        public static int LinePerPage = 20;
        public ActionResult Index()
        {
            using (LibraryDBContext db = new LibraryDBContext())
            {
                string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                User user = db.Users.Find(UserId);
                if (user == null)
                    return View(new ReaderViewModel { HasLogin = false });
                if (user.LastBook == -1)
                    return View(new ReaderViewModel { HasLogin = true, HasChooseBook = false });
                BookInfo book = db.BookInfoes.Find(user.LastBook);
                List<BookLine> lines = new List<BookLine>();
                List<NoteLine> notes = new List<NoteLine>();
                int NotesCount = 0;
                for (int line = user.LastLine; line < user.LastLine + LinePerPage; line++)
                {
                    BookLine bookLine = db.Books.Find(user.LastBook, line);
                    if (bookLine != null)
                        lines.Add(bookLine);
                    NoteLine noteLine = db.Notes.Find(user.LastNote, line);
                    if (noteLine != null)
                    {
                        NotesCount++;
                        notes.Add(noteLine);
                    }
                }
                
                var copyrightUser = db.Users.Find(book.OwnerId);
                string copyrightName;
                if (copyrightUser == null)
                    copyrightName = "公有";
                else
                    copyrightName = copyrightUser.UserName;
                var ownerUserId = db.NoteInfoes.FirstOrDefault(t => t.Id == user.LastNote).OwnerId;
                string ownerName = db.Users.Find(ownerUserId).UserName;

                return View(new ReaderViewModel
                {
                    HasLogin = true,
                    HasChooseBook = true,
                    BookLines = lines,
                    Notes = notes,
                    TotalNotes = NotesCount,
                    StartLine = user.LastLine,
                    EndLine = user.LastLine + LinePerPage - 1,
                    BookName = book.Name,
                    OwnerName = ownerName,
                    CopyrightName = copyrightName,
                    Page = (user.LastLine + LinePerPage - 1) / LinePerPage,
                    TotalPage = (book.TotalLine + LinePerPage - 1) / LinePerPage
                });
            }
        }
        public ActionResult ChangePage(int GotoPage)
        {
            using (LibraryDBContext db = new LibraryDBContext())
            {
                string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                User user = db.Users.Find(UserId);
                BookInfo book = db.BookInfoes.Find(user.LastBook);

                user.LastLine = (GotoPage - 1) * LinePerPage + 1;
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult InitReader(int BookId, int NoteId)
        {
            using (LibraryDBContext db = new LibraryDBContext())
            {
                string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                User user = db.Users.Find(UserId);
                if (user == null)
                    return RedirectToAction("Index");
                user.LastBook = BookId;
                user.LastNote = NoteId;
                user.LastLine = 1;
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult AddNote(int? NoteIndex, string Note)
        {
            using (LibraryDBContext db = new LibraryDBContext())
            {
                if (NoteIndex != null)
                {
                    string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                    User user = db.Users.Find(UserId);
                    NoteLine note = new NoteLine
                    {
                        NoteId = user.LastNote,
                        LineIndex = (int)NoteIndex,
                        UserName = System.Web.HttpContext.Current.User.Identity.Name,
                        Note = Note
                    };
                    db.Notes.AddOrUpdate(note);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
        public ActionResult DeleteNote(int NoteIndex)
        {
            using (LibraryDBContext db = new LibraryDBContext())
            {
                string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                User user = db.Users.Find(UserId);
                NoteLine note = db.Notes.Find(user.LastNote, NoteIndex);
                db.Notes.Remove(note);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}