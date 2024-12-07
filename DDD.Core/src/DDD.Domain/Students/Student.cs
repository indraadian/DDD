namespace DDD.Domain.Students;

public class Student : Entity
{
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
