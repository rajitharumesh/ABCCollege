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
    public class TeacherController : ControllerBase
    {
        public ITeacherService _teacherService { get; set; }
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }


        [HttpGet]
        public Task<IEnumerable<Teacher>> Get()
        {
            return _teacherService.GetAll();
        }


        [HttpPost]
        public async Task AddTeacher([FromBody] TeacherDto teacher)
        {
            await _teacherService.AddTeacher(teacher);
        }

        [HttpPost]
        public async Task UpdateTeacher([FromBody] TeacherDto dto)
        {
            await _teacherService.UpdateTeacher(dto);
        }
    }
}