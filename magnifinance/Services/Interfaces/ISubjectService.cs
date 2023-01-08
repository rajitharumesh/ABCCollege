using Domain.Entities;
using magnifinance.Dtos;

namespace magnifinance.Services.Interfaces
{
    public interface ISubjectService
    {
        public Task<IEnumerable<Subject>> GetAll();
        public Task AddSubject(SubjectDto subject);
        public Task UpdateSubject(SubjectDto subject);
        public Task DeleteSubject(int id);
        public Subject GetOne(int id);
    }
}
