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
    public class CourseController : ControllerBase
    {
        public ICourseService _courseService { get; set; }
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpGet]
        public Task<IEnumerable<Course>> Get()
        {
            return _courseService.GetAll();
        }



        [HttpPost]
        public async Task AddCourse([FromBody] CourseDto course)
        {
            await _courseService.AddCourse(course);
        }

        [HttpPut]
        public async Task UpdateCourse([FromBody] CourseDto dto)
        {
            await _courseService.UpdateCourse(dto);
        }

    }
}