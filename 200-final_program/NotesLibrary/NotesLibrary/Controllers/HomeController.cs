using Microsoft.AspNet.Identity;
using NotesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
            using (LibraryDBContext db = new LibraryDBContext())
            {
                string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                var user = db.Users.Find(UserId);
                bool HasLogin = true;
                if (UserId == null)
                    HasLogin = false;
                if (UserId != null && user == null)
                {
                    string UserName = System.Web.HttpContext.Current.User.Identity.Name;
                    db.Users.Add(new User
                    {
                        Id = UserId,
                        UserName = UserName,
                        Books = "",
                        Notes = "",
                        LastBook = -1
                    });
                    db.SaveChanges();
                }
                int TotalBooks = db.BookInfoes.Max(p => p.Id);
                var basicBooks = new List<BasicBookInfo>();
                int ValidBookCount = 0;
                for (int i = 1; i <= TotalBooks; i++)
                {
                    BookInfo book = db.BookInfoes.Find(i);
                    if (book == null)
                        continue;
                    var copyrightUser = db.Users.Find(book.OwnerId);
                    if (copyrightUser != null)
                        continue;
                    ValidBookCount++;
                    int? NoteId = null;
                    if (HasLogin)
                    {
                        var noteInfo = db.NoteInfoes.Find(book.Id, UserId);
                        if (noteInfo != null)
                            NoteId = noteInfo.Id;
                    }
                    string rank = "0";
                    if (book.RankPeople != 0)
                        rank = (book.TotalRank * 10 / book.RankPeople / 10.0).ToString();
                    basicBooks.Add(new BasicBookInfo
                    {
                        BookId = book.Id,
                        NoteId = NoteId,
                        BookName = book.Name,
                        Rank = rank,
                        ReadPeople = book.ReadPeople
                    });
                }
                return View(new BasicBookViewModel
                {
                    BasicBooks = basicBooks,
                    TotalBook = ValidBookCount
                });
            }
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

                    int MaxBookId = db.BookInfoes.Max(p => p.Id);
                    string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                    int MaxNotetId = db.NoteInfoes.Max(p => p.Id);
                    db.NoteInfoes.Add(new NoteInfo
                    {
                        BookId = MaxBookId + 1,
                        OwnerId = userId,
                        Id = MaxNotetId + 1
                    });
                    var user = db.Users.Find(userId);
                    string bookIdStr = (MaxBookId + 1).ToString();
                    string noteIdStr = (MaxNotetId + 1).ToString();
                    if (user.Books != "")
                    {
                        user.Books += ",";
                        user.Notes += ",";
                    }
                    user.Books += bookIdStr;
                    user.Notes += noteIdStr;
                    db.Users.AddOrUpdate(user);
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
                    BookInfo book;
                    if (model.IsPrivate)
                        book = new BookInfo
                        {
                            Name = model.Name,
                            ISBN = model.ISBN,
                            Author = model.Author,
                            OwnerId = userId,
                            Category = model.Category,
                            Description = model.Description,
                            ReadPeople = 1,
                            TotalLine = counter
                        };
                    else
                        book = new BookInfo
                        {
                            Name = model.Name,
                            ISBN = model.ISBN,
                            Author = model.Author,
                            Category = model.Category,
                            Description = model.Description,
                            ReadPeople = 1,
                            TotalLine = counter
                        };
                    db.BookInfoes.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
            }
        }
    }
}