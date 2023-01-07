using Domain.Entities;
using magnifinance.Dtos;

namespace magnifinance.Services.Interfaces
{
    public interface ICourseService
    {
        public Task<IEnumerable<Course>> GetAll();
        public Task AddCourse(CourseDto course);
        public Task UpdateCourse(CourseDto dto);
        public Task DeleteCourse(CourseDto dto);
    }
}
