using AutoMapper;
using DDD.Application.Dtos;
using DDD.Domain.Entities;

namespace DDD.Application;

public class ApplicationAutoMapper : Profile
{
    public ApplicationAutoMapper()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();
    }
}
