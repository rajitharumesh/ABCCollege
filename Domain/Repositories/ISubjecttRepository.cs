using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ISubjecttRepository : IGenericRepository<Subject>
    {
        IEnumerable<Subject> GetSubjectsByCourseId(int courseId);
        IEnumerable<CourseSubjectDto> GetAllSubjectDetails();
        Subject GetSubject(int subjectId);

    }
}
