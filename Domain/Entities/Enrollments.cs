using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Enrollments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int CourseSubjectID { get; set; }
        public int StudentID { get; set; }
        public double Grade { get; set; }
        public virtual CourseSubject? Course { get; set; }
        public virtual Student? Student { get; set; }
    }
}
