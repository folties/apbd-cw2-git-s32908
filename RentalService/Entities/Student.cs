namespace RentalService.Entities;

public class Student : User
{
    public int StudentNumber { get; set; }

    public Student(string name, string surname, int studentNumber) : base(name, surname)
    {
        StudentNumber = studentNumber;
    }

    public override int MaxActiveRentalDays => 2;
    public override string UserType => "Student";
}