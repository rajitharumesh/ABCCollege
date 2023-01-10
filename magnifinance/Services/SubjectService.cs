using Domain.Dtos;
using Domain.Entities;
using Domain.UnitOfWork;
using magnifinance.Dtos;
using magnifinance.Services.Interfaces;
using System.Linq.Expressions;

namespace magnifinance.Services
{
    public class SubjectService : ISubjectService
    {
        public IUnitOfWork _unitOfWork;
        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddSubject(SubjectDto subjectDto)
        {


            var subject = new Subject
            {
                Description = subjectDto.Description,
                Name = subjectDto.Name,
            };

            subject.CourseSubject = new List<CourseSubject>();

            var courseSubject = new CourseSubject
            {
                CourseID = subjectDto.CourseId,
                TeacherID = subjectDto.TeacherId,
            };
            subject.CourseSubject.Add(courseSubject);

            _unitOfWork.SubjecttRepository.Add(subject);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Subject>> GetAll()
            => await _unitOfWork.SubjecttRepository.GetAllAsync();

        public async Task UpdateSubject(SubjectDto dto)
        {

            Subject subject = _unitOfWork.SubjecttRepository.GetSubject(dto.ID);

            subject.Description = dto.Description;
            subject.Name = dto.Name;

            if (subject.CourseSubject!=null && subject.CourseSubject.Count > 0)
            {
                var courseSubject = subject.CourseSubject.ToList();
                courseSubject[0].SubjectID=dto.ID;
                courseSubject[0].CourseID=dto.CourseId;
                courseSubject[0].TeacherID = dto.TeacherId;
            } else
            {
                subject.CourseSubject = new List<CourseSubject>();
                var courseSubject = new CourseSubject
                {
                    CourseID = dto.CourseId,
                    TeacherID = dto.TeacherId,
                };
                subject.CourseSubject.Add(courseSubject);
            }

            _unitOfWork.SubjecttRepository.Update(subject);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteSubject(int id)
        {
            Subject subject = GetOne(id);
            _unitOfWork.SubjecttRepository.Remove(subject);
            await _unitOfWork.CommitAsync();
        }

        public Subject GetOne(int id)
        {
            Expression<Func<Subject, bool>> exp = (item) => item.ID == id;
            Subject subject = _unitOfWork.SubjecttRepository.Get(exp);
            return subject;
        }

        public async Task<IEnumerable<Subject>> GetAllById(int id)
        {
            Expression<Func<Subject, bool>> exp = (item) => item.ID == id;
            IEnumerable<Subject> subjects = await _unitOfWork.SubjecttRepository.GetAllAsync(exp);
            return subjects;
        }

        public IEnumerable<Subject> GetSubjectsByCourseId(int courseId)
        {
            IEnumerable<Subject> subjects = _unitOfWork.SubjecttRepository.GetSubjectsByCourseId(courseId);
            return subjects;
        }
        public IEnumerable<CourseSubjectDto> GetAllSubjectDetails()
        {
            IEnumerable<CourseSubjectDto> subjects = _unitOfWork.SubjecttRepository.GetAllSubjectDetails();
            return subjects;
        }

        public Subject GetSubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        //public Subject GetSubject(int subjectId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}