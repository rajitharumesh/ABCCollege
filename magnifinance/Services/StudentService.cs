using Domain.Entities;
using Domain.UnitOfWork;
using magnifinance.Dtos;
using magnifinance.Services.Interfaces;

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
    }
}
