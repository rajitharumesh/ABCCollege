using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ABCCollegeDbContext dbContext) : base(dbContext)
        {
            
        }

        public IEnumerable<Teacher> GetTeacherBySubjectId(int subjectId)
        {
            IEnumerable<Teacher> teacher = (from cs in _dbContext.CourseSubjects
                                             join tea in _dbContext.Teachers on cs.TeacherID equals tea.ID
                                             where cs.SubjectID == subjectId
                                             select tea).AsEnumerable();
            return teacher;
        }
    }
}
