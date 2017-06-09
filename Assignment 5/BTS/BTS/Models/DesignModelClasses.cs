//
// author: Jagmeet
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace BTS.Models
{
    // Add your design model classes below

    // Follow these rules or conventions:

    // To ease other coding tasks, the name of the 
    //   integer identifier property should be "Id"
    // Collection properties (including navigation properties) 
    //   must be of type ICollection<T>
    // Valid data annotations are pretty much limited to [Required] and [StringLength(n)]
    // Required to-one navigation properties must include the [Required] attribute
    // Do NOT configure scalar properties (e.g. int, double) with the [Required] attribute
    // Initialize DateTime and collection properties in a default constructor

    public class Incident
    {
        public Incident()
        {
            Students = new List<Student>();
            Instructor = new Instructor();
            dateReported = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime dateReported { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string program { get; set; }
        public string campus { get; set; }
        public string offence { get; set; }

        public ICollection<Student> Students { get; set; }
        public Instructor Instructor { get; set; }

        [StringLength(200)]
        public string DocContentType { get; set; }
        public byte[] Doc { get; set; }
    }

    public class Instructor
    {
        public Instructor()
        {
            Incidents = new List<Incident>();
            Courses = new List<Course>();
        }

        public int Id { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }

        public ICollection<Incident> Incidents { get; set; }
        public ICollection<Course> Courses { get; set; }

    }

    public class Student
    {
        public Student()
        {
            Incidents = new List<Incident>();
            Courses = new List<Course>();
        }

        public int Id { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public string year { get; set; }
        public string studentId { get; set; }

        public ICollection<Incident> Incidents { get; set; }
        public ICollection<Course> Courses { get; set; }

    }

    public class Course
    {

        public Course()
        {
            Instructor = new Instructor();
            Students = new List<Student>();
        }
        public int Id { get; set; }
        public string sectionId { get; set; }
        public string courseCode { get; set; }
        public string courseName { get; set; }
        public string semester { get; set; }

        public Instructor Instructor { get; set; }
        public ICollection<Student> Students { get; set; }


    }
    
    public class RoleClaim
	{
		public int Id { get; set; }

		[Required, StringLength(100)]
		public string Name { get; set; }
	}

}
