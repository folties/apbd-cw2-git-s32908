namespace RentalService.Entities;

public class Employee : User 

{
    public string Department { get; set; }

    public Employee(string name, string surname, string department) : base(name, surname)
    {
        Department = department;
    }

    public override int MaxActiveRentalDays => 5;
    public override string UserType => "Employee";
}
