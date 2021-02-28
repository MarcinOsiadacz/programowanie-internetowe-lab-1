using ProgramowanieInternetowe.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
