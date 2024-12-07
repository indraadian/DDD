using DDD.Application;

namespace DDD.Application.Students;

public class StudentDto : ApplicationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}
