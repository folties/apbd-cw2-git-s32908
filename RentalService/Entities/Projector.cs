namespace RentalService.Entities;

public class Projector : Equipment
{
    public string Resolution { get; set; }
    public int Brightness { get; set; }

    public Projector(string name, string memory, int megapixels) : base(name)
    {
        Resolution = memory;
        Brightness = megapixels;
    }

    public override string ToString()
    {
        return base.ToString() + $", Type: Projector, Brightness: {Brightness}, Resolution: {Resolution}";
    }
}