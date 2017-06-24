using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTS.Controllers
{
    public class IncidentDocsController : Controller
    {
        // Reference to the manager object
        Manager m = new Manager();

        // GET: Photo
        public ActionResult Index()
        {
            return View("index", "home");
        }

        /*           public ActionResult Save(FormCollection formCollection)
                   {
                       if (Request != null)
                       {
                           HttpPostedFileBase file = Request.Files["UploadedFile"];

                           if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                           {
                               string fileName = file.FileName;
                               string fileContentType = file.ContentType;
                               byte[] fileBytes = new byte[file.ContentLength];
                               file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                           }
                       }

                       return View("Index");
                   }*/
        // GET: Photo/5
        // Attention - 8 - Uses attribute routing
        [Route("file/{id}")]
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var o = m.IncidentDocGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Attention - 9 - Return a file content result
                // Set the Content-Type header, and return the photo bytes
                return File(o.Doc, o.DocContentType);
            }
        }

        [Authorize(Roles = "Coordinator Admin , Faculty")]
        public ActionResult pdfDownload(int? id)
        {
            var o = m.IncidentDocGetById(id.GetValueOrDefault());
            if (o != null)
            {
                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = "download.pdf",
                    Inline = false
                };
                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(o.Doc, o.DocContentType);
            }
            else
            {
                return null;
            }
        }

        /*
    // GET: IncidentDocs/Create
    public ActionResult Create()
        {
            return View();
        }

        // POST: IncidentDocs/Create
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

        // GET: IncidentDocs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IncidentDocs/Edit/5
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

        // GET: IncidentDocs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IncidentDocs/Delete/5
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
    }*/
    }
}
