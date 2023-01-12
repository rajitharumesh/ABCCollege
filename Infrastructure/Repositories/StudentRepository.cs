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
            CourseSubject result = getCourseSubjectById(dto);
            if (result !=null && result.ID!=0)
            {
                if (result?.Enrollments?.Count >0)
                {
                    bool isExist = false;
                    foreach (var item in result?.Enrollments)
                    {
                        if (item.CourseSubjectID == dto.CourseSubjectID && item.StudentID == dto.StudentID)
                        {
                            isExist = true;
                        }
                    }
                    if (!isExist)
                    {
                        if (result.Enrollments.Count <1)
                        {
                            result.Enrollments = new List<Enrollments>();
                        }
                        
                        var enrol = new Enrollments();
                        enrol.StudentID = (int)dto.StudentID;
                        enrol.CourseSubjectID = result.ID;
                        result.Enrollments.Add(enrol);
                        _dbContext.CourseSubjects.Update(result);

                    }
                }
                
            } else
            {
                result = new CourseSubject();
                result.CourseID = (int)dto.CourseID;
                result.SubjectID = (int)dto.SubjectID;
                result.TeacherID = (int)dto.TeacherID;

                result.Enrollments = new List<Enrollments>();
                var enrol = new Enrollments();
                enrol.StudentID = (int)dto.StudentID;
                result.Enrollments.Add(enrol);
                _dbContext.CourseSubjects.Add(result);

            }
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
                                                    SubjectName = s.Name,
                                                }
                                             ).AsEnumerable();
            return subjects;
        }

        public int UpdateStudentMapping(Domain.Dtos.CourseSubjectDto dto)
        {
            CourseSubject result = getCourseSubjectById(dto);
            if (result.ID == 0)
            {
                result.CourseID = (int)dto.CourseID;
                result.SubjectID = (int)dto.SubjectID;
                result.TeacherID = (int)dto.TeacherID;

                if (result.Enrollments != null)
                {
                    result.Enrollments = new List<Enrollments>();
                    var item = new Enrollments();
                    item.CourseSubjectID = result.ID;
                    item.StudentID = (int)dto.ID;
                }
            }
            _dbContext.CourseSubjects.Update(result);
            return _dbContext.SaveChanges();

        }

        public CourseSubject getCourseSubjectById(Domain.Dtos.CourseSubjectDto dto)
        {
            var result = (from courseSubject in _dbContext.CourseSubjects.Include(d => d.Enrollments)
                          join dr in _dbContext.Enrollments on courseSubject.ID equals dr.CourseSubjectID into cs
                          from courseSub in cs.DefaultIfEmpty()
                          select courseSubject
                          ).FirstOrDefault();
            return result;

        }
    }
}
