using Domain.Entities;
using magnifinance.Dtos;
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
    }
}