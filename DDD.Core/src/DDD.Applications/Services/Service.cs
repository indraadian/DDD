using AutoMapper;
using DDD.Applications.DTOs;
using DDD.Applications.Interfaces;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces;

namespace DDD.Applications.Services
{
    internal class Service
    {
    }
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IRepository<Student> studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto> GetStudentByIdAsync(Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task AddStudentAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentRepository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            await _studentRepository.DeleteAsync(id);
        }
    }
}
