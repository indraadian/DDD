namespace DDD.Domain.Entities;

public class Student
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime DateOfBirth { get; private set; }

    public Student(string name, DateTime dateOfBirth)
    {
        Id = Guid.NewGuid();
        Name = name;
        DateOfBirth = dateOfBirth;
    }

    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Name cannot be empty.");
        Name = newName;
    }
}
