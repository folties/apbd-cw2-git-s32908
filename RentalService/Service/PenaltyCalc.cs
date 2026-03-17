using RentalService.Entities;

namespace RentalService.Service;

public class PenaltyCalc
{
    private const int DAILY_PENALTY = 10;

    public int CalculatePenalty(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate <= dueDate)
        {
            return 0;
        }
        int lateDays = (returnDate.Date - dueDate.Date).Days;
        return lateDays * DAILY_PENALTY;
    }
}