//
// author: Mona
//


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTS.Controllers
{
    public class StudentBase
    {

        public int Id { get; set; }
        [Display(Name = "Student Name")]
        public string name { get; set; }
        [Display(Name = "Student ID")]
        public string studentId { get; set; }
        [Display(Name = "Student Email")]
        public string emailAddress { get; set; }
        [Display(Name = "Year")]
        public string year { get; set; }

        public ICollection<int> IncidentIds { get; set; }
        public ICollection<int> CourseIds { get; set; }
    }

	public class StudentWithDetails : StudentBase
    {
		public ICollection<IncidentBase> Incidents { get; set; }
    }
}