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
    public class IncidentAdd
    {
        public IncidentAdd()
        {
            IncidentDate = DateTime.Now;
            StudentId = new List<string>();
            StudentName = new List<string>();
        }
        [Required]
        public int id { get; set; }

        [Required]
        [Display(Name = "Incident Date")]
        [DataType(DataType.Date)]
        public DateTime IncidentDate { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public List<string> StudentName { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [RegularExpression(@"^[0-9]{9}")]
        [Display(Name = "Student Id Number")]
        public List<string> StudentId { get; set; }

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

        [Display(Name = "Incident File (PDF)")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase DocUpload { get; set; }

        [Required]
        [Display(Name = "Program")]
        public string program { get; set; }

        [Required]
        [Display(Name = "Campus")]
        public string campus { get; set; }

        [Display(Name = "Minor")]
        public bool isMinor { get; set; }
    }

    public class IncidentAddForm //: IncidentAdd  
    {
        public IncidentAddForm()
        {
            IncidentDate = DateTime.Now;
            StudentId = new List<string>();
            StudentName = new List<string>();
        }
        [Required]
        public int id { get; set; }

        [Required]
        [Display(Name = "Incident Date")]
        [DataType(DataType.Date)]
        public DateTime IncidentDate { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public List<string> StudentName { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [RegularExpression(@"^[0-9]{9}")]
        [Display(Name = "Student Id Number")]
        public List<string> StudentId { get; set; }

        public int InstructorId { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Course Name")]
        [RegularExpression(@"^[A-Z]{3}[0-9]{3}")]
        public string coursecode { get; set; }

        [Required]
        [Display(Name = "Program")]
        public string program { get; set; }

        [Required]
        [Display(Name = "Campus")]
        public string campus { get; set; }

        [Required]
        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        [Display(Name = "Incident File (PDF)")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = ".pdf", ErrorMessage = "Incorrect file format")]
        public string DocUpload { get; set; }

        [Display(Name = "Minor")]
        public bool isMinor { get; set; }
    }
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
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string status { get; set; }
        [Required]
        [Display(Name = "Student ID")]
        public List<string> StudentIds { get; set; }
        [Required]
        [Display(Name = "Student Name")]
        public List<string> StudentNames { get; set; }
        public int InstructorId { get; set; }
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; }

        [Display(Name = "Program")]
        public string program { get; set; }
        [Display(Name = "Campus")]
        public string campus { get; set; }

        [Display(Name = "Incident File (PDF)")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = ".pdf", ErrorMessage = "Incorrect file format")]
        public string DocUpload { get; set; }
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
        public string program { get; set; }
        public string campus { get; set; }

        [Display(Name = "Student ID")]
        public List<string> StudentIds { get; set; }    
        [Display(Name = "Student Name")]
        public List<string> StudentNames { get; set; }
        public int InstructorId { get; set; }

        [Display(Name = "Incident File (PDF)")]
        [DataType(DataType.Upload)]
        
        public HttpPostedFileBase DocUpload { get; set; }
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

        [Display(Name = "Incident Document")]
        public string IncidentDoc { get; set; }
        /*
    {
        get
        {
            return $"/file/{Id}";
        }
    }*/

        [Display(Name = "Offence Level")]
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

    public class IncidentDocs
    {
        public int Id { get; set; }
        public string DocContentType { get; set; }
        public byte[] Doc { get; set; }
    }

    public class IncidentSearch
    {
        public IncidentSearch()
        {
            options = new List<string>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Search Term")]
        public string searchTerm { get; set; }
        public SelectList searchFilter { get; set; }
        public ICollection<string> options { get; set; }
    }

    public class IncidentResponse
    {
        [Required]
        public int incidentID { get; set; }

        [Required]
        public int instructorID { get; set; }

        [Required]
        public string description { get; set; }

        
        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        public string response { get; set; }
    }
}