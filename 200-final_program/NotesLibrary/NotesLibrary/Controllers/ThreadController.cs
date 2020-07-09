using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiThread;
using NotesLibrary.Models;
using ThreadWritter;
using ViewModel;

namespace NotesLibrary.Controllers
{
    public class ThreadController : Controller
    {
        public static MultiLearning multiLearning = new MultiLearning();
        public ActionResult Index()
        {
            var writer = new Writer();
            var messages = multiLearning.GetMessages();
            writer.write(messages.ToArray());
            return View(new ThreadViewModel { Messages = messages});
        }
        public ActionResult Start()
        {
            using (LibraryDBContext db = new LibraryDBContext())
            {
                List<string> bookNames = new List<string>();
                var books = db.BookInfoes.ToList();
                int count = 0;
                foreach (var book in books)
                    bookNames.Add((++count).ToString() + " " + book.Name);
                multiLearning.StartLearning(bookNames);
                return RedirectToAction("Index");
            }
        }
    }
}