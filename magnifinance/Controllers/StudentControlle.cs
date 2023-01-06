using Domain.Entities;
using magnifinance.Dtos;
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
        public Task<IEnumerable<Student>> Get()
        {
            return _studentService.GetAll();
        }


        [HttpPost]
        public async Task AddStudent([FromBody] StudentDto student)
        {
            await _studentService.AddStudent(student);
        }
    }
}