using Microsoft.AspNet.Identity;
using NotesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ViewModel;

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
                var user = db.Users.Find(UserId);
                if (user == null)
                    return View(new ViewModel.ReaderViewModel { HasLogin = false });
                if (user.LastBook == -1)
                    return View(new ViewModel.ReaderViewModel { HasLogin = true, HasChooseBook = false });
                Models.BookInfo book = db.BookInfoes.Find(user.LastBook);
                List<ViewModel.BookLine> lines = new List<ViewModel.BookLine>();
                List<ViewModel.NoteLine> notes = new List<ViewModel.NoteLine>();
                int NotesCount = 0;
                for (int line = user.LastLine; line < user.LastLine + LinePerPage; line++)
                {
                    var bookLine = db.Books.Find(user.LastBook, line);
                    if (bookLine != null)
                        lines.Add(new ViewModel.BookLine { 
                            ContentId = bookLine.ContentId,
                            Line = bookLine.Line,
                            LineIndex = bookLine.LineIndex
                        });
                    var noteLine = db.Notes.Find(user.LastNote, line);
                    if (noteLine != null)
                    {
                        NotesCount++;
                        notes.Add(new ViewModel.NoteLine { 
                            LineIndex = noteLine.LineIndex,
                            Note = noteLine.Note,
                            NoteId = noteLine.NoteId,
                            UserName = noteLine.UserName
                        });
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

                return View(new ViewModel.ReaderViewModel
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
                Models.User user = db.Users.Find(UserId);
                Models.BookInfo book = db.BookInfoes.Find(user.LastBook);

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
                var user = db.Users.Find(UserId);
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
                    Models.User user = db.Users.Find(UserId);
                    Models.NoteLine note = new Models.NoteLine
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
                Models.User user = db.Users.Find(UserId);
                Models.NoteLine note = db.Notes.Find(user.LastNote, NoteIndex);
                db.Notes.Remove(note);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}