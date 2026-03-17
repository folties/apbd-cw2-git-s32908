using RentalService.Entities;

namespace RentalService.Service;

public class LendingService
{
    private Storage storage;
    private PenaltyCalc penaltyCalc;

    public LendingService(Storage storage, PenaltyCalc penaltyCalc)
    {
        this.storage = storage;
        this.penaltyCalc = penaltyCalc;
    }

    public void RentEquipment(int userId, int equipmentId, int rentalDays)
    {
        User user = storage.Users.FirstOrDefault(u => u.Id == userId);
        Equipment equipment = storage.Equipments.FirstOrDefault(e => e.Id == equipmentId);

        if (user == null || equipment == null)
        {
            throw new Exception("No user or equipment found");
        }

        if (!equipment.IsAvailable || equipment.MarkedAsUnavailable)
        {
            throw new Exception("Equipment is not available");
        }
        int activeRentals = storage.Rentals.Count(r => r.User.Id == userId && !r.IsReturned);

        if (activeRentals >= user.MaxActiveRentalDays)
        {
            throw new Exception("User exceed rental limit");
        } 
        Rental rental = new Rental(user, equipment, DateTime.Now, rentalDays); 
        storage.Rentals.Add(rental);
        equipment.IsAvailable = false;
    }

    public int ReturnEquipment(int equipmentId)
    {
        Rental rental = storage.Rentals.FirstOrDefault(r => r.Equipment.Id == equipmentId && !r.IsReturned);

        if (rental == null)
        {
            throw new Exception("No rental found");
        }
        DateTime returnDate = DateTime.Now;
        int penalty = penaltyCalc.CalculatePenalty(rental.ReturnDate, returnDate);
        
        rental.Return(returnDate, penalty);
        rental.Equipment.IsAvailable = !rental.Equipment.IsAvailable;

        return penalty;
    }
    
    public List<Rental> GetActiveRentalsForUser(int userId)
    {
        return storage.Rentals
            .Where(r => r.User.Id == userId && !r.IsReturned)
            .ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return storage.Rentals
            .Where(r => !r.IsReturned && DateTime.Now > r.ReturnDate)
            .ToList();
    }

    public List<Rental> GetAllRentals()
    {
        return storage.Rentals;
    }
}
    
    
