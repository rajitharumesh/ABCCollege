﻿using Domain.Entities;
using Domain.UnitOfWork;
using magnifinance.Dtos;
using magnifinance.Services.Interfaces;

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

            _unitOfWork.SubjecttRepository.Add(subject);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Subject>> GetAll()
            => await _unitOfWork.SubjecttRepository.GetAllAsync();

        public async Task UpdateSubject(SubjectDto subjectDto)
        {
            var subject = new Subject
            {
                ID=subjectDto.ID,
                Description = subjectDto.Description,
                Name = subjectDto.Name,
            };

            _unitOfWork.SubjecttRepository.Update(subject);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteSubject(SubjectDto subjectDto)
        {
            var subject = new Subject
            {
                ID = subjectDto.ID,
                Description = subjectDto.Description,
                Name = subjectDto.Name,
            };

            _unitOfWork.SubjecttRepository.Remove(subject);
            await _unitOfWork.CommitAsync();
        }
    }
}
