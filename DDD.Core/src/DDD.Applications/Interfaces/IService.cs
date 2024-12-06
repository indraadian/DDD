using DDD.Applications.DTOs;

namespace DDD.Applications.Interfaces;

internal interface IService 
{
}
public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
    Task<StudentDto> GetStudentByIdAsync(Guid id);
    Task AddStudentAsync(StudentDto studentDto);
    Task UpdateStudentAsync(StudentDto studentDto);
    Task DeleteStudentAsync(Guid id);
}
