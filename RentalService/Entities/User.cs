namespace RentalService.Entities;

public abstract class User
{
    private static int id = 1;
    public static int Id {get; set;}
    public string Name {get; set;}
    public string Surname {get; set;}

    public User(string name, string surname)
    {
        Id = id++;
        Name = name;
        Surname = surname;
    }
    
    public abstract int MaxActiveRentalDays { get; }
    public abstract string UserType { get; }

    public override string ToString()
    {
        return $"ID: {Id}, {Name} {Surname}, Type: {UserType}, Limit: {MaxActiveRentalDays}";
    }
    
}