namespace RentalService.Entities;

public class Laptop : Equipment
{
    public int Size { get; set; }
    public string Color { get; set; }

    public Laptop(string name, int size, string color) : base(name)
    {
        Size = size;
        Color = color;
    }

    public override string ToString()
    {
        return base.ToString() + $", Type: Laptop, Size: {Size}, Color: {Color}";
    }
}