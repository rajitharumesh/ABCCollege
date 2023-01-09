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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ABCCollegeDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<StudentDto> GetAllStudents()
        {
            var result = (from student in _dbContext.Students

                          join enrolment in _dbContext.Enrollments on student.ID equals enrolment.StudentID into stuEnro
                          from studentEnrolment in stuEnro.DefaultIfEmpty()

                          join couSub in _dbContext.CourseSubjects on studentEnrolment.CourseSubjectID equals couSub.ID into dayDelvs
                          from coSuEnrolment in dayDelvs.DefaultIfEmpty()

                          join subj in _dbContext.Subjects on coSuEnrolment.SubjectID equals subj.ID into subject
                          from courseSub in subject.DefaultIfEmpty()

                          join course in _dbContext.Courses on coSuEnrolment.CourseID equals course.ID into course
                          from courseObj in course.DefaultIfEmpty()

                          join teacher in _dbContext.Teachers on coSuEnrolment.TeacherID equals teacher.ID into teacher
                          from teacherObj in teacher.DefaultIfEmpty()


                          select new StudentDto()
                          {
                              ID = student.ID,
                              FirstName = student.FirstName,
                              LastName = student.LastName,
                              BirthDate = student.BirthDate,
                              EnrollmentDate = student.EnrollmentDate,
                              Name = student.FirstName + " " + student.LastName,
                              RegistrationNo = student.RegistrationNo,
                              CourseID = (int?)coSuEnrolment.CourseID,
                              SubjectID = (int?)coSuEnrolment.SubjectID,
                              TeacherID = (int?)coSuEnrolment.TeacherID,
                              CourseDescription = (string?)courseObj.Description,
                              TeacherName = (string?)teacherObj.FirstName + " " + (string?)teacherObj.LastName,
                              CourseTitle = (string?)courseObj.Title,
                          }).AsEnumerable();
            return result;
        }
    }
}
