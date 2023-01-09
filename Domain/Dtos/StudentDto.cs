using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class StudentDto
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Name { get; set; }
        public string? CourseDescription { get; set; }
        public string? TeacherName { get; set; }
        public string? CourseTitle { get; set; }
        public string? StudentId { get; set; }
        public string? RegistrationNo { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int? CourseID { get; set; }
        public int? SubjectID { get; set; }
        public int? TeacherID { get; set; }
        public int? CourseSubjectID { get; set; }
        public int? Grade { get; set; }
    }
}
