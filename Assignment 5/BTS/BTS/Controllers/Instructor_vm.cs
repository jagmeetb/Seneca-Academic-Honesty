//
// author: Jagmeet
//


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTS.Controllers
{
    public class InstructorBase
    {
        public InstructorBase()
        {
            IncidentIds = new List<int>();
            CourseIds = new List<int>();

        }

        public int Id { get; set; }
        [Display(Name = "Instructor Name")]
        public string name { get; set; }
        [Display(Name = "Email address")]
        public string emailAddress { get; set; }

        public ICollection<int> IncidentIds { get; set; }
        public ICollection<int> CourseIds { get; set; }
    }

    public class InstructorWithDetails
    {
        public InstructorWithDetails()
        {
            Incidents = new List<IncidentBase>();
            Courses = new List<CourseBase>();
        }

        public ICollection<IncidentBase> Incidents { get; set; }
        public ICollection<CourseBase> Courses { get; set; }
    }
}