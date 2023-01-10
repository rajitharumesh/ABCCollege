using Domain.Entities;
using Domain.UnitOfWork;
using magnifinance.Dtos;
using magnifinance.Services.Interfaces;
using System.Linq.Expressions;

namespace magnifinance.Services
{
    public class StudentService : IStudentService
    {
        public IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddStudent(StudentDto studentDto)
        {
            var student = new Student
            {
             FirstName=studentDto.FirstName,
             LastName=studentDto.LastName,
             BirthDate=studentDto.BirthDate,
             RegistrationNo = studentDto.RegistrationNo,
             EnrollmentDate = studentDto.EnrollmentDate
            };

            student.Enrollments = new List<Enrollments>();

            var enrollments = new Enrollments
            {
                StudentID = studentDto.ID,
                CourseSubjectID = studentDto.CourseSubjectID,
                Grade= studentDto.Grade
            };
            student.Enrollments.Add(enrollments);


            _unitOfWork.StudentRepository.Add(student);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
            => await _unitOfWork.StudentRepository.GetAllAsync();


        public async Task UpdateStudent(StudentDto dto)
        {
            Student student = GetOne(dto.ID);
            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.BirthDate = dto.BirthDate;
            student.RegistrationNo = dto.RegistrationNo;

            _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteStudent(int id)
        {
            Student student = GetOne(id);
            _unitOfWork.StudentRepository.Remove(student);
            await _unitOfWork.CommitAsync();
        }

        public Student GetOne(int id)
        {
            Expression<Func<Student, bool>> exp = (item) => item.ID == id;
            Student student = _unitOfWork.StudentRepository.Get(exp);
            return student;
        }

        public IEnumerable<Domain.Dtos.StudentDto> GetStudentList()
        {
            IEnumerable<Domain.Dtos.StudentDto> students = _unitOfWork.StudentRepository.GetStudentList();
            return students;
        }

        public IEnumerable<Domain.Dtos.StudentDto> GetAllStudents()
        {
            IEnumerable<Domain.Dtos.StudentDto> students = _unitOfWork.StudentRepository.GetAllStudents();
            return students;
        }

        public IEnumerable<Domain.Dtos.StudentDto> GetSubjectsByCourseId()
        {
            IEnumerable<Domain.Dtos.StudentDto> students = _unitOfWork.StudentRepository.GetSubjectsByCourseId();
            return students;
        }

        public Task UpdateStudentMapping(Domain.Dtos.CourseSubjectDto dto)
        {
            _unitOfWork.StudentRepository.AddStudentMapping(dto);
            return _unitOfWork.CommitAsync();
        }


        public Task AddStudentMapping(Domain.Dtos.CourseSubjectDto dto)
        {
            _unitOfWork.StudentRepository.AddStudentMapping(dto);
            return _unitOfWork.CommitAsync();
        }
    }
}
