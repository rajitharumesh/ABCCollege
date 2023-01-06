using Domain.Entities;
using magnifinance.Dtos;

namespace magnifinance.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetAll();
        public Task AddStudent(StudentDto student);
    }
}
