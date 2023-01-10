using Domain.Dtos;
using Domain.Entities;
using magnifinance.Dtos;
using magnifinance.Services;
using magnifinance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentDto = magnifinance.Dtos.StudentDto;

namespace magnifinance.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        public IStudentService _studentService { get; set; }
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public IEnumerable<Domain.Dtos.StudentDto> Get()
        {
            return _studentService.GetStudentList();
        }


        [HttpPost]
        public async Task AddStudent([FromBody] StudentDto student)
        {
            await _studentService.AddStudent(student);
        }

        [HttpPut]
        public async Task UpdateStudent([FromBody] StudentDto student)
        {
            await _studentService.UpdateStudent(student);
        }

        [HttpDelete("{id}")]
        public Task Delete([FromRoute] int id)
        {
            return _studentService.DeleteStudent(id);
        }

        [HttpGet("details")]
        public IEnumerable<Domain.Dtos.StudentDto> GetAllStudents()
        {
            return _studentService.GetSubjectsByCourseId();
        }

        // student mapping
        [HttpPost("mapping")]
        public async Task AddStudentMapping([FromBody] Domain.Dtos.CourseSubjectDto student)
        {
            await _studentService.AddStudentMapping(student);
        }

        [HttpPut("mapping")]
        public async Task UpdateStudentMapping([FromBody] Domain.Dtos.CourseSubjectDto student)
        {
            await _studentService.UpdateStudentMapping(student);
        }
    }
}