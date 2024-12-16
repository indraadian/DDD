using DDD.Application.Services;
using DDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DDD.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly StudentService _service;
    public StudentController(ILogger<StudentController> logger, StudentService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet(Name = "GetById")]
    public async Task<Student> GetById(Guid id)
    {
        return await _service.GetByIdAsync(id);
    }

    [HttpGet(Name = "GetAll")]
    public async Task<IEnumerable<Student>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet(Name = "GetAll")]
    public async Task<IEnumerable<Student>> Update()
    {
        return await _service.GetAllAsync();
    }
}
