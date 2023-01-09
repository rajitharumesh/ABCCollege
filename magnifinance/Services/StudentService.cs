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

        public IEnumerable<Domain.Dtos.StudentDto> GetAllStudents()
        {
            IEnumerable<Domain.Dtos.StudentDto> students = _unitOfWork.StudentRepository.GetAllStudents();
            return students;

        }
    }
}
