using Domain.Entities;
using Domain.UnitOfWork;
using magnifinance.Dtos;
using magnifinance.Services.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Linq.Expressions;

namespace magnifinance.Services
{
    public class CourseService : ICourseService
    {
        public IUnitOfWork _unitOfWork;
        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCourse(CourseDto courseDto)
        {
            var course = new Course
            {
                Description  = courseDto.Description,
                Title = courseDto.Title,
            };

            _unitOfWork.CourseRepository.Add(course);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Course>> GetAll()
            => await _unitOfWork.CourseRepository.GetAllAsync();

        public async Task UpdateCourse(CourseDto dto)
        {
            Course course = GetOne(dto.ID);
            course.Description = dto.Description;
            course.Title = dto.Title;

            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCourse(int id)
        {
            Course course = GetOne(id);
            _unitOfWork.CourseRepository.Remove(course);
            await _unitOfWork.CommitAsync();
        }

        public Course GetOne(int id)
        {
            Expression<Func<Course, bool>> exp = (item) => item.ID==id ;
            Course course = _unitOfWork.CourseRepository.Get(exp);
            return course;
        }
    }
}
