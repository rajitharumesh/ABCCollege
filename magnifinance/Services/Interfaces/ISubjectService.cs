using Domain.Entities;
using magnifinance.Dtos;

namespace magnifinance.Services.Interfaces
{
    public interface ISubjectService
    {
        public Task<IEnumerable<Subject>> GetAll();
        public Task AddSubject(SubjectDto subject);
    }
}
