using Lab4ED1.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Lab4ED1.Controllers
{
    public class StickerListsController : Controller
    {
        DBConnection.DBConnection Datos = DBConnection.DBConnection.getInstance;
        
        // GET: StickerLists
        public ActionResult Index()
        {
            return View();
        }

        // GET: StickerLists/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StickerLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StickerLists/Create
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

        // GET: StickerLists/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StickerLists/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StickerLists/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StickerLists/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult UploadDictionaryLists ()
        {
            return View();
        }
        [HttpPost]

        public ActionResult UploadDictionaryLists(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (!file.FileName.EndsWith(".json"))
                {
                    return View();
                }
                if (file.ContentLength > 0)
                {
                    var jsonfile = new JsonFile();

                      Datos.ListadoCromos = jsonfile.ListRead(file.InputStream);
                    return RedirectToAction("Index");
                }
            }
          
            return View();
        }
        [HttpGet]
        public ActionResult UploadDictionaryState()
        {
            return View();
        }
        [HttpPost]

        public ActionResult UploadDictionaryState(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (!file.FileName.EndsWith(".json"))
                {
                    return View();
                }
                if (file.ContentLength > 0)
                {
                    var jsonfile = new JsonFile();

                    Datos.EstadoCromo = jsonfile.ListState(file.InputStream);
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}
