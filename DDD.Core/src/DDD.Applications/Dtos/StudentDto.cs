using DDD.Application.Dtos.Base;

namespace DDD.Application.Dtos;

public class StudentDto : ApplicationDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;            // Student's last name
    public DateTime DateOfBirth { get; set; }        // Student's birth date
    public string Gender { get; set; } = default!;               // Gender of the student (Male, Female, etc.)
    public string Address { get; set; }              // Student's home address
    public string PhoneNumber { get; set; } = default!;          // Student's phone number
    public string Email { get; set; } = default!;                // Student's email address
    public List<string> Courses { get; set; }        // List of courses the student is enrolled in
    public double GPA { get; set; }                  // Grade Point Average of the student
    public DateTime EnrollmentDate { get; set; }
}
