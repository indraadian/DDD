using AutoMapper;
using DDD.Domain;
using DDD.Domain.Students;

namespace DDD.Application.Students;

public class StudentService : ApplicationService<StudentDto>, IStudentService
{
    public StudentService(IRepository<Entity, Guid> repository, IMapper mapper)
        : base(repository, mapper)
    {

    }
}
