using Domain.Entities;
using Domain.UnitOfWork;
using magnifinance.Dtos;
using magnifinance.Services.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;

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
    }
}
