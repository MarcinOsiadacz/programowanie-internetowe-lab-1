using ProgramowanieInternetowe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramowanieInternetowe.Controllers
{
    public class MissingPersonsController : Controller
    {
        private readonly ProgramowanieInternetoweDbContext _db = ProgramowanieInternetoweDbContext.Create();

        // GET: MissingPersons
        public ActionResult Index()
        {
            var missingPersons = _db.MissingPersons.ToList();

            return View(missingPersons);
        }

        // GET: MissingPersons/Details/5
        public ActionResult Details(int id)
        {
            var missingPerson = _db.MissingPersons.Where(p => p.Id == id).FirstOrDefault();

            return View(missingPerson);
        }

        // GET: MissingPersons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MissingPersons/Create
        [HttpPost]
        public ActionResult Create(MissingPersonModel collection)
        {
            try
            {
                string photoUrlToBeAssigned = "~/Content/img/default.jpg";

                if (collection.PhotoFile != null)
                {
                    string pic = Path.GetFileName(collection.PhotoFile.FileName);
                    string newFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + pic;

                    collection.PhotoFile.SaveAs(Path.Combine(Server.MapPath("~/Content/img"), newFileName));
                    photoUrlToBeAssigned = "~/Content/img/" + newFileName;
                };

                var missingPersonToCreate = new MissingPersonModel()
                {
                    FirstName = collection.FirstName,
                    LastName = collection.LastName,
                    Gender = collection.Gender,
                    PhotoUrl = photoUrlToBeAssigned
                };

                _db.MissingPersons.Add(missingPersonToCreate);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MissingPersons/Edit/5
        public ActionResult Edit(int id)
        {
            var missingPerson = _db.MissingPersons.Where(p => p.Id == id).FirstOrDefault();

            return View(missingPerson);
        }

        // POST: MissingPersons/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MissingPersonModel collection)
        {
            try
            {
                var missingPersonToEdit = _db.MissingPersons.Where(p => p.Id == id).FirstOrDefault();

                if (missingPersonToEdit != null)
                {
                    missingPersonToEdit.FirstName = collection.FirstName;
                    missingPersonToEdit.LastName = collection.LastName;
                    missingPersonToEdit.Gender = collection.Gender;

                    if (collection.PhotoFile != null)
                    {
                        string pic = Path.GetFileName(collection.PhotoFile.FileName);
                        string newFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + pic;

                        collection.PhotoFile.SaveAs(Path.Combine(Server.MapPath("~/Content/img"), newFileName));
                        missingPersonToEdit.PhotoUrl = "~/Content/img/" + newFileName;
                    };
                }
                _db.SaveChanges();
                return RedirectToAction("Details", new { id });
            }
            catch
            {
                return View();
            }
        }

        //// GET: MissingPersons/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: MissingPersons/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
