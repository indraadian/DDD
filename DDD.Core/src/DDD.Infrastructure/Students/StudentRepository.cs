using DDD.Domain;
using DDD.Domain.Students;
using DDD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Students;

public class StudentRepository : Repository<Student, Guid>, IStudentRepository
{
    public StudentRepository(SchoolDbContext context) : base(context)
    {
    }
}
