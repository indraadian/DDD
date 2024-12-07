using AutoMapper;
using DDD.Application.Students;
using DDD.Domain.Students;

namespace DDD.Application;

public class ApplicationAutoMapper : Profile
{
    public ApplicationAutoMapper()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();
    }
}
