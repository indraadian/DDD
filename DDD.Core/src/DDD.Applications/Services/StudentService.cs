using AutoMapper;
using DDD.Application.Dtos;
using DDD.Application.Interfaces;
using DDD.Application.Interfaces.Base;
using DDD.Application.Services.Base;
using DDD.Domain.Entities;
using DDD.Domain.Entities.Base;

namespace DDD.Application.Services;

public class StudentService : ApplicationService<Student>, IStudentService
{
    public StudentService(IMapper mapper, IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
    }
}
