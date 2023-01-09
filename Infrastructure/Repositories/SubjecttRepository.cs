using Domain.Dtos;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SubjecttRepository : GenericRepository<Subject>, ISubjecttRepository
    {

        public SubjecttRepository(ABCCollegeDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Subject> GetSubjectsByCourseId(int courseId)
        {
            IEnumerable<Subject> subjects = (from d in _dbContext.Subjects
                                             join dr in _dbContext.CourseSubjects on d.ID equals dr.SubjectID
                                             where dr.CourseID == courseId
                                             select d).AsEnumerable();
            return subjects;
        }

        public IEnumerable<CourseSubjectDto> GetAllSubjectDetails()
        {
            var result = (from sub in _dbContext.Subjects
                          join couSub in _dbContext.CourseSubjects on sub.ID equals couSub.SubjectID into dayDelvs
                     from courseSub in dayDelvs.DefaultIfEmpty()

                     join cou in _dbContext.Courses on courseSub.CourseID equals cou.ID into course
                     from courseObj in course.DefaultIfEmpty()

                     join tea in _dbContext.Teachers on courseSub.TeacherID equals tea.ID into teacher
                     from teacherObj in teacher.DefaultIfEmpty()


                     select new CourseSubjectDto()
                     {
                         ID = sub.ID,
                         Name = sub.Name,
                         Description = sub.Description,
                         CourseID = (int?)courseSub.CourseID,
                         SubjectID = (int?)courseSub.SubjectID,
                         TeacherID = (int?)courseSub.TeacherID,
                         CourseDescription = (string?)courseObj.Description,
                         TeacherName = (string?)teacherObj.FirstName + " " + (string?)teacherObj.LastName,
                         CourseTitle = (string?)courseObj.Title,
                         LastName = (string?)teacherObj.LastName,
                         FirstName = (string?)teacherObj.FirstName,
                         BirthDate=(DateTime)teacherObj.BirthDate,
                         Salary=(Double)teacherObj.Salary,
                     }).AsEnumerable();
            return result;
        }
    }
}
