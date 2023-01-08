using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class CourseSubjectDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? CourseDescription { get; set; }
        public string? TeacherName { get; set; }
        public string? CourseTitle { get; set; }
        public int? CourseID { get; set; }
        public int? SubjectID { get; set; }
        public int? TeacherID { get; set; }
    }
}
