using Domain.Entities;
using Domain.UnitOfWork;
using magnifinance.Dtos;
using magnifinance.Services.Interfaces;
using System.Linq.Expressions;

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
            Teacher teacher = GetOne(dto.ID);
            teacher.FirstName = dto.FirstName;
            teacher.LastName = dto.LastName;
            teacher.BirthDate = dto.BirthDate;
            teacher.Salary = dto.Salary;
            
            _unitOfWork.TeacherRepository.Update(teacher);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteTeacher(int id)
        {
            Teacher teacher = GetOne(id);
            _unitOfWork.TeacherRepository.Remove(teacher);
            await _unitOfWork.CommitAsync();
        }

        public Teacher GetOne(int id)
        {
            Expression<Func<Teacher, bool>> exp = (item) => item.ID == id;
            Teacher teacher = _unitOfWork.TeacherRepository.Get(exp);
            return teacher;
        }

        public IEnumerable<Teacher> GetTeacherBySubjectId(int subjectId)
        {
            IEnumerable<Teacher> teacher = _unitOfWork.TeacherRepository.GetTeacherBySubjectId(subjectId);
            return teacher;
        }
    }
}
