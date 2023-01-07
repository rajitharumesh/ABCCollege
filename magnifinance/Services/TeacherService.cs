using Domain.Entities;
using Domain.UnitOfWork;
using magnifinance.Dtos;
using magnifinance.Services.Interfaces;

namespace magnifinance.Services
{
    public class TeacherService : ITeacherService
    {
        public IUnitOfWork _unitOfWork;
        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddTeacher(TeacherDto teacherDto)
        {
            var teacher = new Teacher
            {
                FirstName= teacherDto.FirstName,
                LastName= teacherDto.LastName,
                BirthDate= teacherDto.BirthDate,
                Salary = teacherDto.Salary
            };

            _unitOfWork.TeacherRepository.Add(teacher);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAll()
            => await _unitOfWork.TeacherRepository.GetAllAsync();

        public async Task UpdateTeacher(TeacherDto dto)
        {
            var teacher = new Teacher
            {
                ID = dto.ID,
                FirstName = dto.FirstName,
                LastName=dto.LastName,
                BirthDate=dto.BirthDate,
                Salary=dto.Salary,
            };

            _unitOfWork.TeacherRepository.Update(teacher);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteTeacher(TeacherDto dto)
        {
            var teacher = new Teacher
            {
                ID = dto.ID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                Salary = dto.Salary,
            };

            _unitOfWork.TeacherRepository.Remove(teacher);
            await _unitOfWork.CommitAsync();
        }
    }
}
