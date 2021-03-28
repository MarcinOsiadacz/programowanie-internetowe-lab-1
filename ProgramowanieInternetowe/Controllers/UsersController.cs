using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProgramowanieInternetowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramowanieInternetowe.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly ProgramowanieInternetoweDbContext _db = ProgramowanieInternetoweDbContext.Create();

        // GET: Users
        public ActionResult Index()
        {
            return View(_db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            var user = _db.Users.Where(p => p.Id == id).FirstOrDefault();
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            var userToEdit = _db.Users.Where(p => p.Id == id).FirstOrDefault();

            return View(userToEdit);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ApplicationUser editedUserData)
        {
            try
            {
                var userToEdit = _db.Users.Where(p => p.Id == id).FirstOrDefault();

                if (userToEdit != null)
                {
                    userToEdit.UserName = editedUserData.UserName;
                    userToEdit.Email = editedUserData.Email;
                }
                _db.SaveChanges();

                return RedirectToAction("Details", new { id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            var userToEdit = _db.Users.Where(p => p.Id == id).FirstOrDefault();

            return View(userToEdit);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                var userToDelete= _db.Users.Where(p => p.Id == id).FirstOrDefault();

                if (userToDelete != null)
                {
                    _db.Users.Remove(userToDelete);
                    _db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
