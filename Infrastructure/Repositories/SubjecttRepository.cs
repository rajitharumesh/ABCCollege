using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SubjecttRepository : GenericRepository<Subject>, ISubjecttRepository
    {
        public SubjecttRepository(ABCCollegeDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Subject> GetSubjectsByCourseId(int courseId)
        {
            IEnumerable<Subject> subjects = (from d in _dbContext.Subjects
                                             join dr in _dbContext.CourseSubjects on d.ID equals dr.SubjectID
                                             where dr.CourseID == courseId
                                             select d).AsEnumerable();
            return subjects;
        }

    }
}
