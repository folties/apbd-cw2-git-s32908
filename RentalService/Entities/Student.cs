namespace RentalService.Entities;

public class Student : User
{
    public string StudentNumber { get; set; }

    public Student(string name, string surname, string studentNumber) : base(name, surname)
    {
        StudentNumber = studentNumber;
    }

    public override int MaxActiveRentalDays => 2;
    public override string UserType => "Student";
}