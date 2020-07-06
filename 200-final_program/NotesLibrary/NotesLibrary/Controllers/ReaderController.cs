using NotesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesLibrary.Controllers
{
    public class ReaderController : Controller
    {
        // GET: Reader
        public ActionResult Index()
        {
            using (LibraryDBContext db = new LibraryDBContext())
            {
                List<BookLine> lines = new List<BookLine>();
                List<NoteViewModel> notes = new List<NoteViewModel>();
                int NotesCount = 0;
                for (int i = 1; i <= 20; i++)
                {
                    BookLine bookLine = db.Books.Find(1, i);
                    if (bookLine != null)
                        lines.Add(bookLine);
                    NoteLine noteLine = db.Notes.Find(1, i);
                    if (noteLine != null)
                    {
                        NotesCount++;
                        notes.Add(new NoteViewModel {
                            Index = NotesCount,
                            LineIndex = noteLine.LineIndex,
                            Note = noteLine.Note
                        });
                    }
                }
                ReaderViewModel model = new ReaderViewModel {
                    BookLines = lines,
                    Notes = notes,
                    NoteIndex = null,
                    Page = 5
                };
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Index(ReaderViewModel model)
        {
            using (LibraryDBContext db = new LibraryDBContext())
            {
                if (model.NoteIndex != null)
                {
                    NoteLine note = new NoteLine
                    {
                        ContentId = 1,
                        LineIndex = (int)model.NoteIndex,
                        Note = model.Note
                    };
                    db.Notes.Add(note);
                    db.SaveChanges();
                } 
                return RedirectToAction("Index");
            }
        }
    }
}