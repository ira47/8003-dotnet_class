using Microsoft.AspNet.Identity;
using NotesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NotesLibrary.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index(int? BookId, int? NoteId)
        {
            if (BookId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (LibraryDBContext db = new LibraryDBContext())
            {
                var book = db.BookInfoes.Find(BookId);

                var ownerUser = db.Users.Find(book.OwnerId);
                string ownerName;
                if (ownerUser == null)
                    ownerName = "";
                else
                    ownerName = ownerUser.UserName;
                bool hasLogin = true;
                string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                var user = db.Users.Find(UserId);
                if (user == null)
                    hasLogin = false;

                    return View(new DetailBookViewModel
                {
                    BookId = (int)BookId,
                    NoteId = NoteId,
                    Name = book.Name,
                    ISBN = book.ISBN,
                    Author = book.Author,
                    OwnerName = ownerName,
                    Category = book.Category,
                    Description = book.Description,
                    Rank = (book.TotalRank * 10 / book.RankPeople / 10.0).ToString(),
                    RankPeople = book.RankPeople,
                    TotalLine = book.TotalLine,
                    HasLogin = hasLogin
                });
            }
        }
    }
}