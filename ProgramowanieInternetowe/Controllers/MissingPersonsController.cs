using ProgramowanieInternetowe.Helpers;
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
                string photoPath = "~/Content/img/default.jpg";

                if (collection.PhotoFile != null)
                {
                    string pic = Path.GetFileName(collection.PhotoFile.FileName);

                    collection.PhotoFile.SaveAs(Path.Combine(Server.MapPath("~/Content/img"), pic));
                    photoPath = "~/Content/img/" + pic;
                };

                var missingPersonToCreate = new MissingPersonModel()
                {
                    FirstName = collection.FirstName,
                    LastName = collection.LastName,
                    Gender = collection.Gender,
                    PhotoUrl = photoPath
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

        private string FileUpload(HttpPostedFileBase file)
        {
            if (file == null)
                return "~/Content/img/default.jpg";
            else
            {
                string pic = Path.GetFileName(file.FileName);
                string path = "~/Content/img" + pic;

                file.SaveAs(path);
                return path;
            }    
        }


        //// GET: MissingPersons/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: MissingPersons/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

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
