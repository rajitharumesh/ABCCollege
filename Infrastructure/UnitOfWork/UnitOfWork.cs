using Domain.Repositories;
using Domain.UnitOfWork;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ABCCollegeDbContext _dbContext;
        private ICourseRepository _courseRepository;
        private ISubjecttRepository _subjecttRepository;
        private IStudentRepository _studentRepository;
        private ITeacherRepository _teacherRepository;


        public UnitOfWork(ABCCollegeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICourseRepository CourseRepository
        {
            get { return _courseRepository = _courseRepository ?? new CourseRepository(_dbContext); }
        }

        public ISubjecttRepository SubjecttRepository
        {
            get { return _subjecttRepository = _subjecttRepository ?? new SubjecttRepository(_dbContext); }
        }

        public IStudentRepository StudentRepository
        {
            get { return _studentRepository = _studentRepository ?? new StudentRepository(_dbContext); }
        }

        public ITeacherRepository TeacherRepository
        {
            get { return _teacherRepository = _teacherRepository ?? new TeacherRepository(_dbContext); }
        }

        public void Commit()
            => _dbContext.SaveChanges();

        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();

        public void Rollback()
            => _dbContext.Dispose();

        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
