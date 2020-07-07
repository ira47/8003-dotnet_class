using Microsoft.AspNet.Identity;
using NotesLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NotesLibrary.Controllers
{
    public class HomeController : Controller
    {
        [DllImport("TextServer", EntryPoint = "divide", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DivideTextFile(StringBuilder inFileName, StringBuilder outFileName, int _ziPerLine);

        // GET: Library
        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                UserName = System.Web.HttpContext.Current.User.Identity.Name,
                UserId = System.Web.HttpContext.Current.User.Identity.GetUserId()
            };
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddBookViewModel model)
        {
            using (LibraryDBContext db = new LibraryDBContext())
            {
                if (ModelState.IsValid)
                {
                    string FileName = Path.GetFileName(model.TextFile.FileName);
                    string UploadPath = System.AppDomain.CurrentDomain.BaseDirectory + "Content\\RawText\\";
                    string DividendPath = System.AppDomain.CurrentDomain.BaseDirectory + "Content\\DividendText\\";
                    model.TextFile.SaveAs(UploadPath + FileName);

                    StringBuilder inFile = new StringBuilder();
                    StringBuilder outFile = new StringBuilder();
                    inFile.Append(UploadPath + FileName);
                    outFile.Append(DividendPath + FileName);
                    DivideTextFile(inFile, outFile, 80);

                    var book = new BookInfo
                    {
                        Name = model.Name,
                        ISBN = model.ISBN,
                        Author = model.Author,
                        OwnerId = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                        Category = model.Category,
                        Description = model.Description
                    };
                    db.BookInfoes.Add(book);
                    db.SaveChanges();

                    int MaxContentId = db.BookInfoes.Max(p => p.Id);
                    int counter = 0;
                    string TextLine;
                    StreamReader file = new StreamReader(DividendPath + FileName, Encoding.GetEncoding("GB2312"));
                    while ((TextLine = file.ReadLine()) != null)
                    {
                        var bookLine = new BookLine
                        {
                            ContentId = MaxContentId,
                            LineIndex = counter + 1,
                            Line = TextLine
                        };
                        db.Books.Add(bookLine);
                        counter++;
                    }

                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
            }
        }
    }
}