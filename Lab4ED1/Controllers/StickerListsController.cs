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
        [HttpGet]
        public ActionResult IndexState()
        {
            return View();
        }

        // GET: StickerLists/Details/5
        [HttpPost]
        public ActionResult IndexState(FormCollection collection)
        {
            var key = "";
            if(collection["Pais"].ToUpper() == "ESPECIAL")
            {
                key = collection["Pais"] + collection["Numero"];
                ViewBag.Message = key;
            } else
            {
                key = collection["Pais"] + "_" + collection["Numero"];
                ViewBag.Message = key;

            }
            return RedirectToAction(nameof(DetailsState), new { key = key });
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index (FormCollection collection)
        {
            var key = collection["Pais"];
                return RedirectToAction(nameof(Details), new { key = key });
            
        }
        public ActionResult Details(string key)
        {
            try
            {
                if (Datos.ListadoCromos.Count != 0)
                {
                    var Detalle = Datos.ListadoCromos[key];
                    ViewBag.Message = key;
                    View(Detalle);
                }
                return View();

            }
            catch (Exception)
            {
                ViewBag.Message = "NO se ha encontrado ningún dato";
                return RedirectToAction(nameof(Index));
            }
        }
        public ActionResult DetailsState(string key)
        {

            try
            {
                if (Datos.EstadoCromo.Count != 0)
                {
                    var Detalle = Datos.EstadoCromo[key];
                    ViewBag.Message = key;
                    var detail = "El estado de su cromo es: " + "  " +Datos.EstadoCromo[key].ToString();
                    View((object)detail);
                }
                return View();

            }
            catch (Exception)
            {
                ViewBag.Message = "NO se ha encontrado ningún dato";
                return RedirectToAction(nameof(Index));
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
                    return RedirectToAction(nameof(Index));
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
                    return RedirectToAction(nameof(IndexState));
                }
            }

            return View();
        }
        public ActionResult ChangeCurrentState(string key)
        {
            if(!Datos.EstadoCromo[key])
            {
                Datos.EstadoCromo[key] = true;
            } else
            {
                Datos.EstadoCromo[key] = false;
            }
            return RedirectToAction(nameof(DetailsState), new {  key });
        }
    }
}
