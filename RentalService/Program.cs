using RentalService.Entities;
using RentalService.Service;

class Program
{
    static void Main()
    {
        Storage storage = new Storage();
        UserService userService = new UserService(storage);
        EquipmentService equipmentService = new EquipmentService(storage);
        PenaltyCalc penaltyCalc = new PenaltyCalc();
        LendingService lendingService = new LendingService(storage, penaltyCalc);
        ReportService reportService = new ReportService(storage);

        userService.AddUser((new Student("Nazar", "Korchenyuk", "s32908")));
        userService.AddUser((new Employee("Tom", "Holland", "s3145")));
        
        equipmentService.AddEquipment(new Laptop("MacBook", 16, "Navy"));
        equipmentService.AddEquipment(new Camera("Canon", 64, 24));
        equipmentService.AddEquipment(new Projector("SmartProjector", "2.35:1", 8));
        
        Console.WriteLine("Equipment: ");
        foreach (Equipment equipment in equipmentService.GetAllEquipments())
            {
            Console.WriteLine(equipment);
            }
        lendingService.RentEquipment(1,1, 3);
        Console.WriteLine("Success:>");

        try
        {
            lendingService.RentEquipment(1,1,5);
        } catch  (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        int penalty = lendingService.ReturnEquipment(1);
        Console.WriteLine($"Returned, penalty: {penalty}");
        
        reportService.PrintSummary();
    }
}