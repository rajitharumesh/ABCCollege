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
            return _studentService.GetAllStudents();
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
    }
}