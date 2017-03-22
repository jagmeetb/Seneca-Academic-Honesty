//
// author: Jagmeet
//
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTS.Controllers
{
    [Authorize]
    public class IncidentAdd
    {
        public IncidentAdd()
        {
            IncidentDate = DateTime.Now;
        }
        [Required]
        public int id { get; set; }

        [Required]
        [Display(Name = "Incident Date")]
        [DataType(DataType.Date)]
        public DateTime IncidentDate { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Required, StringLength(100)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [RegularExpression(@"^[0-9]{9}")]
        [Display(Name = "Student Id Number")]
        public string StudentId { get; set; }

        public int InstructorId { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Course Name")]
        [RegularExpression(@"^[A-Z]{3}[0-9]{3}")]
        public string coursecode { get; set; }

        [Required]
        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        public string description { get; set; } 

        [Required]
        [Display(Name = "Program")]
        public string program { get; set; }

        [Required]
        [Display(Name = "Campus")]
        public string campus { get; set; }

        [Display(Name = "Offence")]
        public SelectList OffenceList { get; set; }
    }

    [Authorize]
    public class IncidentAddForm : IncidentAdd  
    {
        public IncidentAddForm()
        {
            //StudentIds = new List<string>();
            //StudentNames = new List<string>();
        }


        
    }
    [Authorize]
    public class IncidentEditForm
    {
        public IncidentEditForm()
        {
            StudentIds = new List<string>();
            StudentNames = new List<string>();
        }

        [Required]
        public int id { get; set; }

        public DateTime IncidentDate { get; set; }
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
        public string program { get; set; }
        public string campus { get; set; }
        
        [Display(Name = "Offence")]
        public SelectList OffenceList { get; set; }
        
        //public bool minor { get; set; }
    }

    [Authorize]
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

        [Display(Name = "Offence")]
        public string OffenceList { get; set; }
    }

    // View model class for a minor offence entity
    public class Offence
    {
        public int Id { get; set; }

        public string offenceTerm { get; set; }
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
        [Display(Name = "Program")]
        public string program { get; set; }
        [Display(Name = "Campus")]
        public string campus { get; set; }
        public string offence { get; set; }

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