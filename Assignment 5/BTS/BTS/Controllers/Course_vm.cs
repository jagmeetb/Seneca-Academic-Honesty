//
// author: Mona
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTS.Controllers
{
    public class CourseBase
    {
        public CourseBase()
        {
            Instructor = new InstructorBase();
            StudentIds = new List<string>();
        }

        public string sectionId { get; set; }
        public string courseCode { get; set; }
        public string courseName { get; set; }
        public string semester { get; set; }

        public InstructorBase Instructor { get; set; }
        public ICollection<string> StudentIds { get; set; }
    }

    public class CourseWithDetails : CourseBase
    {
        public CourseWithDetails()
        {
            Instructor = new InstructorBase();
            StudentIds = new List<string>();
            Incidents = new List<IncidentBase>();
        }

        public ICollection<IncidentBase> Incidents { get; set; }
    }
}