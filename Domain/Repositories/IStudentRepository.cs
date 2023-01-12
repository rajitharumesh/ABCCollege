using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        IEnumerable<StudentDto> GetAllStudents();
        IEnumerable<StudentDto> GetStudentList();
        IEnumerable<StudentDto> GetSubjectsByCourseId();
        int UpdateStudentMapping(Domain.Dtos.CourseSubjectDto dto);
        int AddStudentMapping(Domain.Dtos.CourseSubjectDto dto);
        CourseSubject getCourseSubjectById(Domain.Dtos.CourseSubjectDto dto);
    }
}
