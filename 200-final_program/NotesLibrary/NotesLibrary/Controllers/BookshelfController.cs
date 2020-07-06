using NotesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                return View(db.Contents.ToList());
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (LibraryDBContext db = new LibraryDBContext())
            {
                var model = db.Contents.Find(id);
                return View(model);
            }
        }
    }
}