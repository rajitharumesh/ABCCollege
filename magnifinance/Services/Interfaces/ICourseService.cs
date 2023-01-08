using Domain.Entities;
using magnifinance.Dtos;
using System.Linq.Expressions;

namespace magnifinance.Services.Interfaces
{
    public interface ICourseService
    {
        public Task<IEnumerable<Course>> GetAll();
        public Task AddCourse(CourseDto course);
        public Task UpdateCourse(CourseDto dto);
        public Task DeleteCourse(int id);
        public Course GetOne(int id);
    }
}
