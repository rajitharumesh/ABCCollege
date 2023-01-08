using Domain.Entities;
using magnifinance.Dtos;

namespace magnifinance.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetAll();
        public Task AddStudent(StudentDto student);
        public Task UpdateStudent(StudentDto dto);
        public Task DeleteStudent(int id);
        public Student GetOne(int id);
    }
}
