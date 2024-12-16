using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD.WebApp.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<HomeController> _logger;

        public StudentController(IStudentService studentService, ILogger<HomeController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        #region Interface
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllAsync();
            return View(students);
        }
        public async Task<IActionResult> Form(Guid? id)
        {
            if (!id.HasValue) return View(null);

            var student = await _studentService.GetByIdAsync(id.Value);
            return View(student);
        }
        #endregion

        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        public async Task<IActionResult> AddStudent([FromBody] Student Student)
        {
            await _studentService.AddAsync(Student);
            return CreatedAtAction(nameof(GetStudentById), new { id = Student.Id }, Student);
        }

        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] Student Student)
        {
            if (id != Student.Id) return BadRequest();
            await _studentService.UpdateAsync(Student);
            return NoContent();
        }

        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            await _studentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
