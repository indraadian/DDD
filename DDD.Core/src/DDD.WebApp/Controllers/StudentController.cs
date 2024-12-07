using DDD.Application;
using DDD.Application.Students;
using Microsoft.AspNetCore.Mvc;

namespace DDD.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {
            await _studentService.AddAsync(studentDto);
            return CreatedAtAction(nameof(GetStudentById), new { id = studentDto.Id }, studentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] StudentDto studentDto)
        {
            if (id != studentDto.Id) return BadRequest();
            await _studentService.UpdateAsync(studentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            await _studentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
