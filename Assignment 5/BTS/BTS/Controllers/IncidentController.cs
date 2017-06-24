//
// author: Jagmeet
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTS.Controllers
{
    public class IncidentController : Controller
    {
        private Manager m = new Manager();
        public List<Offence> Offences { get; set; }


        // GET: incidentResponse
        [Authorize(Roles = "Coordinator Admin")]
        public ActionResult incidentResponse(int? id)
        {
            var form = new IncidentResponse();
            form.incidentID = id.GetValueOrDefault();
            var x = m.IncidentGetOne(id.GetValueOrDefault());
            form.instructorID = x.Instructor.Id;
            form.description = x.description;
            return View(form);
        }

        [HttpPost]
        public ActionResult incidentResponse(int? id, IncidentResponse newItem)
        {
            bool result = m.closeIncident(id.GetValueOrDefault(), newItem.response);

            return RedirectToAction("Index");
        }

        // GET: Search
        public ActionResult Search()
        {
            var form = new IncidentSearch();
            form.options.Add("All");
            form.options.Add("Description");
            form.options.Add("Student");
            form.options.Add("Instructor");
            form.options.Add("Course");
            return View(form);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Search(int? id, IncidentSearch newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("search");
            }

            var foundIncidents = m.IncidentSearch(newItem);
            if (foundIncidents == null || foundIncidents.Count() == 0)
            {
                return RedirectToAction("search");
            }


            return View("SearchPost", foundIncidents);
        }



        // GET: Incident
        [Authorize(Roles = "Coordinator Admin , Faculty")]
        public ActionResult Index()
        {
            m.LoadData();
            if (User.IsInRole("Coordinator Admin"))
            {
                return View(m.IncidentGetAllOpen());
            }
            return View(m.IncidentGetAll());
        }

        // GET: Incident
        [Authorize(Roles = "Coordinator Admin")]
        public ActionResult Index2()
        {
            return View(m.IncidentGetAll());
        }

        // GET: Incident/Create
        [Authorize(Roles = "Coordinator Admin , Faculty")]
        public ActionResult Create()
        {
            // Create a form
            var form = new IncidentAddForm();
            form.StudentId = new List<string>();
            form.StudentName = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                form.StudentId.Add("");
                form.StudentName.Add("");
            }

            return View(form);
        }
        // ############################################################
        // POST: Incident/Create
        [HttpPost]
        [Authorize(Roles = "Coordinator Admin , Faculty")]
        public ActionResult Create(IncidentAdd newItem)
        {


            /*
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create", AutoMapper.Mapper.Map<IncidentAddForm>(newItem));
            }*/

            if (newItem.DocUpload.ContentType != null && newItem.DocUpload.ContentType != "application/pdf")
            {
                IncidentAddForm form = new IncidentAddForm();
                form.StudentId = new List<string>();
                form.StudentName = new List<string>();

                form.campus = newItem.campus;
                form.coursecode = newItem.coursecode;
                form.description = newItem.description;
                form.IncidentDate = newItem.IncidentDate;
                form.InstructorName = newItem.InstructorName;
                form.isMinor = newItem.isMinor;
                form.program = newItem.program;
                form.StudentName = newItem.StudentName;
                form.StudentId = newItem.StudentId;
                return View(form);
            }

            // Process the input
            var addedItem = m.IncidentAdd(newItem);

            if (addedItem == null)
            {
                return RedirectToAction("Create", AutoMapper.Mapper.Map<IncidentAddForm>(newItem));
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }
        }
        // ############################################################
        // GET: Incident/Details/5
        [Authorize(Roles = "Coordinator Admin , Faculty")]
        public ActionResult Details(int? id)

        {
            var o = m.IncidentGetOne(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
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



        // ############################################################
        // GET: Incident/Edit/5
        [Authorize(Roles = "Coordinator Admin , Faculty")]
        public ActionResult Edit(int? id)
        {
            var o = m.IncidentGetOne(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Create and configure an "edit form"

                // Notice that o is a IncidentBase object
                // We must map it to a IncidentEditForm object
                // Notice that we can use AutoMapper anywhere,
                // and not just in the Manager class!
                var editForm = AutoMapper.Mapper.Map<IncidentEditForm>(o);

                editForm.InstructorName = o.Instructor.name;
                editForm.InstructorId = o.Instructor.Id;

                editForm.StudentIds = new List<string>();
                editForm.StudentNames = new List<string>();
                foreach (var stud in o.Students)
                {
                    editForm.StudentIds.Add(stud.studentId);
                    editForm.StudentNames.Add(stud.name);
                }

                for (int i = 0; i < 20; i++)
                {
                    editForm.StudentIds.Add("");
                    editForm.StudentNames.Add("");
                }

                //editForm.OffenceList = new SelectList(this.Offences, "Id", "offenceTerm");

                if (o.offence == "Minor")
                {
                    //editForm.OffenceList.SelectedValue = 0;
                }

                return View(editForm);
                //return View();
            }
        }
        // ############################################################
        // POST: Incident/Edit/5
        [HttpPost]
        [Authorize(Roles = "Coordinator Admin , Faculty")]
        public ActionResult Edit(int ? id, IncidentEdit newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                // Our "version 1" approach is to display the "edit form" again
                return RedirectToAction("edit", new { id = newItem.Id });
            }

            if (id.GetValueOrDefault() != newItem.Id)
            {
                // This appears to be data tampering, so redirect the user away
                return RedirectToAction("index");
            }
            if (newItem.DocUpload.ContentType != "application/pdf")
            {
                return RedirectToAction("edit", new { id = newItem.Id });
            }


            for (int i = 0; i < newItem.StudentIds.Count(); i++)
            {
                newItem.StudentIds.Remove("");
                newItem.StudentNames.Remove("");
            }
           
            // Attempt to do the update
            var editedItem = m.IncidentEdit(newItem);

            if (editedItem == null)
            {
                // There was a problem updating the object
                // Our "version 1" approach is to display the "edit form" again
                return RedirectToAction("edit", new { id = newItem.Id });
            }
            else
            {
                // Show the details view, which will have the updated data
                return RedirectToAction("details", new { id = newItem.Id });
            }
        }

        public ActionResult ShowEditIncidentForm()
        {
            // Attention 27 - Create and configure a view model object

            var form = new IncidentEditForm();

            // Attention 28 - SelectList objects
            //form.OffenceList = new SelectList(this.Offences, "Id", "offenceTerm");

            // Attention 29 - Carefully study the PlanCourses view
            return View(form);
        }

        private void LoadOffence()
        {
            Offences = new List<Offence>();
            Offences.Add(new Offence { Id = 1001, offenceTerm = "Minor" });
            Offences.Add(new Offence { Id = 1002, offenceTerm = "Major" });
        }


        /* try
         {
             // TODO: Add update logic here

             return RedirectToAction("Index");
         }
         catch
         {
             return View();
         }
     }*/
        // ############################################################
        /*
        // GET: Incident/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Incident/Delete/5
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
        */
    }
}
