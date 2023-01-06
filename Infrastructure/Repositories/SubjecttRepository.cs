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
    }
}
