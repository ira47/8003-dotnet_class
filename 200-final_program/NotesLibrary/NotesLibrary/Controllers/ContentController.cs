using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotesLibrary.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace NotesLibrary.Controllers
{
    public class ContentController : Controller
    {
        [DllImport("TextServer", EntryPoint = "divide", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DivideTextFile(StringBuilder inFileName, StringBuilder outFileName, int _ziPerLine);

        private LibraryDBContext db = new LibraryDBContext();

        // GET: Content
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddBasicContentViewModel model)
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
                
                var content = new Content
                {
                    Name = model.Name,
                    ISBN = model.ISBN,
                    Author = model.Author,
                    Description = model.Description,
                    IsPrivate = model.IsPrivate,
                    Category = ""
                };
                db.Contents.Add(content);
                db.SaveChanges();

                int MaxContentId = db.Contents.Max(p => p.Id);
                int counter = 0;
                string TextLine;
                StreamReader file = new StreamReader(DividendPath + FileName, Encoding.GetEncoding("GB2312"));
                while ((TextLine = file.ReadLine()) != null)
                {
                    var bookLine = new BookLine
                    {
                        ContentId = MaxContentId,
                        LineIndex = counter+1,
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