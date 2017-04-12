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

        public IncidentController()
        {
            // Load the offence minor
            LoadOffence();
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


        private Manager m = new Manager();

        public List<Offence> Offences { get; set; }

        public IncidentController()
        {
            // Load the offence minor
            LoadOffence();
        }

        // GET: Incident
        public ActionResult Index()
        {
            m.LoadData();
            return View(m.IncidentGetAll());
        }



        // GET: Incident/Create
        [Authorize]
        public ActionResult Create()
        {
            // Create a form
            var form = new IncidentAddForm();
            form.OffenceList = new SelectList(this.Offences, "Id", "offenceTerm");
            return View(form);
        }
        // ############################################################
        // POST: Incident/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(IncidentAdd newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
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
        // ############################################################
        // GET: Incident/Edit/5
        [Authorize]
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

                editForm.StudentIds.Add("");
                editForm.StudentNames.Add("");

                editForm.OffenceList = new SelectList(this.Offences, "Id", "offenceTerm");
                
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
        [Authorize]
        [HttpPost]
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

            newItem.StudentIds.Remove("");
            newItem.StudentNames.Remove("");

            string offenceID = newItem.OffenceList;
            newItem.OffenceList = this.Offences.Where(a => a.Id == int.Parse(offenceID)).First().offenceTerm;

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
            form.OffenceList = new SelectList(this.Offences, "Id", "offenceTerm");

            // Attention 29 - Carefully study the PlanCourses view
            return View(form);
        }

        private void LoadOffence()
        {
            Offences = new List<Offence>();
            Offences.Add(new Offence { Id = 1001, offenceTerm = "Minor"});
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
