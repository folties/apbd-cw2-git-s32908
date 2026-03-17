namespace RentalService.Service;

public class ReportService
{
    private Storage storage;
    
    public ReportService(Storage storage)
    {
        this.storage = storage;
    }

    public void PrintSummary()
    {
        Console.WriteLine("======== RENTAL SERVICE SUMMARY ========");
        Console.WriteLine($"Total users: {storage.Users.Count}");
        Console.WriteLine($"Total equipment items: {storage.Equipments.Count}");
        Console.WriteLine($"Available equipment: {storage.Equipments.Count(e => e.IsAvailable && !e.MarkedAsUnavailable)}");
        Console.WriteLine($"Unavailable equipment: {storage.Equipments.Count(e => e.MarkedAsUnavailable)}");
        Console.WriteLine($"Active rentals: {storage.Rentals.Count(r => !r.IsReturned)}");
        Console.WriteLine($"Overdue rentals: {storage.Rentals.Count(r => !r.IsReturned && DateTime.Now > r.ReturnDate)}");
        Console.WriteLine($"Returned rentals: {storage.Rentals.Count(r => r.IsReturned)}");
        Console.WriteLine($"Total penalties: {storage.Rentals.Sum(r => r.Penalty)}");
    }
}