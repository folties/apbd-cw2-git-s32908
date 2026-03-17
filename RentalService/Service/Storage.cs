using RentalService.Entities;

namespace RentalService.Service;

public class Storage
{
    public List<User> Users { get; set; } = new();
    public List<Equipment> Equipments { get; set; } = new();
    public List<Rental> Rentals { get; set; } = new();
}