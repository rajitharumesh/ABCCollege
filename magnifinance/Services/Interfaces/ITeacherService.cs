using Domain.Entities;
using magnifinance.Dtos;

namespace magnifinance.Services.Interfaces
{
    public interface ITeacherService
    {
        public Task<IEnumerable<Teacher>> GetAll();
        public Task AddTeacher(TeacherDto teacher);
    }
}
