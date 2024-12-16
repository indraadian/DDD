using DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.DataContext.ModelConfigurations;

public class StudentConfigurations : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(s => s.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.LastName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Email).IsRequired().HasMaxLength(255);
        builder.Property(s => s.Gender).IsRequired().HasMaxLength(10);
        builder.Property(s => s.Address).HasMaxLength(500);
        builder.Property(s => s.PhoneNumber).HasMaxLength(15);

        builder.HasIndex(e => new { e.FirstName, e.LastName })
                   .HasDatabaseName("IX_FirstName_LastName"); // Custom index name

        builder.HasData(
            new Student
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(2000, 5, 15),
                Gender = "Male",
                Address = "123 Elm Street, Springfield, USA",
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com",
                Courses = new List<string> { "Math", "Science", "History" }, // Serialized into JSON
                GPA = 3.5,
                EnrollmentDate = new DateTime(2020, 9, 1),
            },
            new Student
            {
                FirstName = "Jane",
                LastName = "Smith",
                DateOfBirth = new DateTime(1999, 11, 25),
                Gender = "Female",
                Address = "456 Oak Avenue, Springfield, USA",
                PhoneNumber = "9876543210",
                Email = "jane.smith@example.com",
                Courses = new List<string> { "English", "Biology", "Chemistry" },
                GPA = 3.8,
                EnrollmentDate = new DateTime(2021, 1, 15),
            }
        );
    }
}
