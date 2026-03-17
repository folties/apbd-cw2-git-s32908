using Microsoft.VisualBasic;

namespace RentalService.Entities;

public class Rental
{
    public User  User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public int Penalty { get; set; }

    public bool IsReturned => ActualReturnDate.HasValue;
    public bool IsOverdue => !IsReturned && DateTime.Now > ReturnDate;
    
    public Rental(User user, Equipment equipment, DateTime rentalDate, int rentalDays)
    {
        User = user;
        Equipment = equipment;
        RentalDate = rentalDate;
        ReturnDate = rentalDate.AddDays(rentalDays);
        ActualReturnDate = null;
        Penalty = 0;
    }

    public void Return(DateTime returnDate, int penalty)
    {
        ActualReturnDate = returnDate;
        Penalty = penalty;
    }

    public override string ToString()
    {
        return $"{User.Name} {User.Surname} rented {Equipment.Name} on {RentalDate:d}, " +
               $"due {ReturnDate:d}, returned: {ActualReturnDate?.ToShortDateString() ?? "Not yet"}, " +
               $"penalty: {Penalty}";
    }
    
}