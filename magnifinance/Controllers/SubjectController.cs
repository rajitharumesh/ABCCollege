using Domain.Entities;
using magnifinance.Dtos;
using magnifinance.Services;
using magnifinance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace magnifinance.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {
        public ISubjectService _subjectService { get; set; }
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }


        [HttpGet]
        public Task<IEnumerable<Subject>> Get()
        {
            return _subjectService.GetAll();
        }


        [HttpPost]
        public async Task AddSubject([FromBody] SubjectDto subject)
        {
            await _subjectService.AddSubject(subject);
        }

        [HttpPut]
        public async Task UpdateSubject([FromBody] SubjectDto subject)
        {
            await _subjectService.UpdateSubject(subject);
        }

        [HttpDelete("{id}")]
        public Task Delete([FromRoute] int id)
        {
            return _subjectService.DeleteSubject(id);
        }

        [HttpGet("{id}")]
        public Subject GetSubjectById([FromRoute] int id)
        {
            return _subjectService.GetOne(id);
        }

        [HttpGet("course/{id}")]
        public IEnumerable<Subject> GetSubjectsByCourseId([FromRoute] int id)
        {
            return _subjectService.GetSubjectsByCourseId(id);
        }
    }
}