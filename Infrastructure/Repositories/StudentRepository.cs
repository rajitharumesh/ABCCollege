using Domain.Dtos;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public int AddStudentMapping(Domain.Dtos.CourseSubjectDto dto)
        {
            //_dbContext.CourseSubjects.Add(dto);
            //int dd = _dbContext.SaveChanges();
            //Enrollments en = new Enrollments();
            //en.CourseSubjectID = dd;
            //en.StudentID = dto.s
            return _dbContext.SaveChanges();
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
                              CourseSubjectID = courseObj.ID,
                              Grade = (int?)studentEnrolment.Grade
                          }).AsEnumerable();
            return result;
        }

        public IEnumerable<StudentDto> GetStudentList()
        {
            IEnumerable<StudentDto>? subjects = (from d in _dbContext.Students.Include(d => d.Enrollments)
                                                 join dr in _dbContext.Enrollments on d.ID equals dr.StudentID into subj
                                                 from courseSub in subj.DefaultIfEmpty()

                                                 select new StudentDto()
                                                 {
                                                     ID = d.ID,
                                                     FirstName = d.FirstName,
                                                     LastName = d.LastName,
                                                     BirthDate = d.BirthDate,
                                                     EnrollmentDate = d.EnrollmentDate,
                                                     Name = d.FirstName + " " + d.LastName,
                                                     RegistrationNo = d.RegistrationNo,
                                                 }
                                 ).AsEnumerable();
            return subjects;
        }

        public IEnumerable<StudentDto> GetSubjectsByCourseId()
        {
            IEnumerable<StudentDto> subjects = (from d in _dbContext.CourseSubjects
                                                join c in _dbContext.Courses on d.CourseID equals c.ID
                                                join s in _dbContext.Subjects on d.SubjectID equals s.ID
                                                join t in _dbContext.Teachers on d.TeacherID equals t.ID
                                                join e in _dbContext.Enrollments on d.ID equals e.CourseSubjectID
                                                join st in _dbContext.Students on e.StudentID equals st.ID
                                                select new StudentDto()
                                                {
                                                    ID = s.ID,
                                                    FirstName = st.FirstName,
                                                    LastName = st.LastName,
                                                    BirthDate = st.BirthDate,
                                                    EnrollmentDate = st.EnrollmentDate,
                                                    Name = st.FirstName + " " + st.LastName,
                                                    RegistrationNo = st.RegistrationNo,
                                                    CourseID = (int?)d.CourseID,
                                                    SubjectID = (int?)d.SubjectID,
                                                    TeacherID = (int?)d.TeacherID,
                                                    CourseDescription = (string?)c.Description,
                                                    TeacherName = (string?)t.FirstName + " " + (string?)t.LastName,
                                                    CourseTitle = (string?)c.Title,
                                                    CourseSubjectID = d.ID,
                                                    Grade = (int?)e.Grade,
                                                    SubjectName = s.Name
                                                }
                                             ).AsEnumerable();
            return subjects;
        }

        public int UpdateStudentMapping(Domain.Dtos.CourseSubjectDto dto)
        {
            //CourseSubject csa=new CourseSubject();
            //dto.CourseID = dto.CourseID;
            //dto.SubjectID = dto.SubjectID;
            //dto.TeacherID = dto.TeacherID;
            //dto.ID = dto.ID;

            //CourseSubject? cs = _dbContext.CourseSubjects.Find(csa);
            //if (cs != null)
            //{
            //    _dbContext.CourseSubjects.Update(csa);
            //}
            return _dbContext.SaveChanges();

        }
    }
}
