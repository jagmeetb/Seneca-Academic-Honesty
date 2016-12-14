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
    public class IncidentEditForm
    {
        public IncidentEditForm()
        {
            StudentIds = new List<string>();
            StudentNames = new List<string>();
        }

        [Required]
        public int id { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public ICollection<string> StudentIds { get; set; }
        [Required]
        public ICollection<string> StudentNames { get; set; }
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
    }

    public class IncidentEdit
    {
        public IncidentEdit()
        {
            StudentIds = new List<string>();
            StudentNames = new List<string>();
        }

        public int Id { get; set; }
        public string description { get; set; }
        public string status { get; set; }

        [Display(Name = "Student ID")]
        public ICollection<string> StudentIds { get; set; }
        [Display(Name = "Student Name")]
        public ICollection<string> StudentNames { get; set; }
        public int InstructorId { get; set; }
    }

    public class IncidentBase
    {
        public IncidentBase()
        {
            dateReported = DateTime.Now;
        }

        
        public int Id { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Date Reported")]
        public DateTime dateReported { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
    }

    public class IncidentWithDetails : IncidentBase
    {
        public IncidentWithDetails()
        {
            dateReported = DateTime.Now;
            Instructor = new InstructorBase();
            Students = new List<StudentBase>();

        }
        public InstructorBase Instructor { get; set; }
        public ICollection<StudentBase> Students { get; set; }
    }
}