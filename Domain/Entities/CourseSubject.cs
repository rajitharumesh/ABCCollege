using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class CourseSubject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int SubjectID { get; set; }
        public int TeacherID { get; set; }

        public virtual Course? Course { get; set; } // 2023 - AL
        public virtual Subject? Subject { get; set; }// Maths
        public virtual Teacher? Teacher { get; set; } // Amila

        public virtual ICollection<Enrollments>? Enrollments { get; set; }
    }
}
