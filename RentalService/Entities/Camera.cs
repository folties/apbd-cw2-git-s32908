namespace RentalService.Entities;

public class Camera : Equipment
{
    public int Memory { get; set; }
    private int Megapixels { get; set; }

    public Camera(string name, int memory, int megapixels) : base(name)
    {
        Memory = memory;
        Megapixels = megapixels;
    }

    public override string ToString()
    {
        return base.ToString() + $", Type: Camera, Memory: {Memory}, Megapixels: {Megapixels}";
    }
}