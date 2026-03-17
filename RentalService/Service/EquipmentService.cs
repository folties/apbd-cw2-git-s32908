using RentalService.Entities;

namespace RentalService.Service;

public class EquipmentService
{
    private Storage storage;

    public EquipmentService(Storage storageInput)
    {
        storage = storageInput;
    }

    public void AddEquipment(Equipment equipment)
    {
        storage.Equipments.Add(equipment);
    }

    public List<Equipment> GetAllEquipments()
    {
        return storage.Equipments;
    }
    public Equipment GetEquipment(int id)
    {
        return storage.Equipments.FirstOrDefault(x => x.Id == id);
    }

    public List<Equipment> GetAvailableEquipment()
    {
        return storage.Equipments.Where(e => e.IsAvailable && !e.MarkedAsUnavailable).ToList();
    }

    public void MarkAsUnavailable(int equipmentId)
    {
        var equipment = GetEquipment(equipmentId);
        if (equipment == null)
        {
            throw new Exception("Equipment not found");
        }
        equipment.MarkedAsUnavailable = true;
        equipment.IsAvailable = false;
    }
}