using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using DDD.Infrastructure.DataContext;
using DDD.Infrastructure.Persistence.Base;

namespace DDD.Infrastructure.Persistence;

public class StudentRepository : Repository<Student>, IStudentRepository
{
    public StudentRepository(SchoolDbContext context) : base(context)
    {
    }
}
