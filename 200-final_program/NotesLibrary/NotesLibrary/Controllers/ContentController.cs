using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotesLibrary.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace NotesLibrary.Controllers
{
    public class ContentController : Controller
    {
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
                var content = new Content { 
                    Name = model.Name,
                    ISBN = model.ISBN,
                    Author = model.Author,
                    Description = model.Description,
                    IsPrivate = model.IsPrivate,
                    Category = "",
                    HasText = false
                };
                db.Contents.Add(content);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}