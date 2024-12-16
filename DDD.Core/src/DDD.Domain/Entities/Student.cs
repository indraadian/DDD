using DDD.Domain.Entities.Base;
using Newtonsoft.Json;

namespace DDD.Domain.Entities;

public class Student : Entity
{
    public Student()
    {
        
    }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;            // Student's last name
    public DateTime DateOfBirth { get; set; }        // Student's birth date
    public string Gender { get; set; } = default!;               // Gender of the student (Male, Female, etc.)
    public string Address { get; set; }              // Student's home address
    public string PhoneNumber { get; set; } = default!;          // Student's phone number
    public string Email { get; set; } = default!;                // Student's email address
    public List<string> Courses { get; set; }        // List of courses the student is enrolled in
    public double GPA { get; set; }                  // Grade Point Average of the student
    public DateTime EnrollmentDate { get; set; }     // The date when the student enrolled

    public override PropertiesModel PropertiesModel
    {
        get
        {
            var propertiesModel = new StudentPropertiesModel();
            if (string.IsNullOrEmpty(Properties))
            {
                try
                {
                    propertiesModel = JsonConvert.DeserializeObject<StudentPropertiesModel>(Properties);
                }
                catch
                {
                    propertiesModel = new StudentPropertiesModel();
                }
            }
            return propertiesModel!;
        }
    }
    // Constructor
    public Student(string firstName,
                   string lastName,
                   DateTime dateOfBirth,
                   string gender,
                   string address,
                   string phoneNumber,
                   string email,
                   List<string> courses,
                   double gpa,
                   DateTime enrollmentDate)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
        Courses = courses;
        GPA = gpa;
        EnrollmentDate = enrollmentDate;
    }

    // Method to get full name of the student
    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    // Method to get the student's age
    public int GetAge()
    {
        var age = DateTime.Now.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > DateTime.Now.AddYears(-age)) age--;
        return age;
    }

    // Method to calculate the student's average GPA (in case of multiple semesters/subjects)
    public double CalculateAverageGPA(List<double> gpas)
    {
        if (gpas == null || gpas.Count == 0) return 0;

        double totalGPA = 0;
        foreach (var gpa in gpas)
        {
            totalGPA += gpa;
        }
        return totalGPA / gpas.Count;
    }


}

public class StudentPropertiesModel : PropertiesModel
{

}

