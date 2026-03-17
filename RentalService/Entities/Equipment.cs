namespace RentalService.Entities;

public abstract class Equipment
{
    private static int id = 1;

    public int Id { get; }
    public string Name { get; set; }
    public bool IsAvailable { get; set; }
    public bool MarkedAsUnavailable { get; set; }

    protected Equipment(string name){
        Id = Id++;
        Name = name;
        IsAvailable = true;
        MarkedAsUnavailable = false;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Available: {IsAvailable}, Unavailable flag: {MarkedAsUnavailable}";
    }
}