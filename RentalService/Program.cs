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

        userService.AddUser(new Student("Nazar", "Korchenyuk", "s32908"));
        userService.AddUser(new Employee("Tom", "Holland", "s3123"));
        userService.AddUser(new Student("Anna", "Nowak", "s11111"));
        userService.AddUser(new Employee("Kate", "Smith", "s2141"));

        equipmentService.AddEquipment(new Laptop("MacBook", 16, "Navy"));
        equipmentService.AddEquipment(new Camera("Canon", 64, 24));
        equipmentService.AddEquipment(new Projector("SmartProjector", "2.35:1", 8));
        equipmentService.AddEquipment(new Laptop("Lenovo", 32, "Black"));
        equipmentService.AddEquipment(new Camera("Sony", 128, 48));

        Console.WriteLine("Equipment:");
        foreach (Equipment equipment in equipmentService.GetAllEquipments())
        {
            Console.WriteLine(equipment);
        }

        Console.WriteLine();

        Console.WriteLine("Users:");
        foreach (User user in userService.GetAllUsers())
        {
            Console.WriteLine(user);
        }

        Console.WriteLine();

        Console.WriteLine("Correct rental:");
        lendingService.RentEquipment(1, 1, 3);
        Console.WriteLine("Success:>");

        Console.WriteLine();

        Console.WriteLine("Invalid rental attempt:");
        try
        {
            lendingService.RentEquipment(1, 1, 5);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine();

        Console.WriteLine("Return on time:");
        int penalty1 = lendingService.ReturnEquipment(1);
        Console.WriteLine($"Returned, penalty: {penalty1}");

        Console.WriteLine();

        Console.WriteLine("Delayed return:");

        User delayedUser = storage.Users.First(u => u.Id == 2);
        Equipment delayedEquipment = storage.Equipments.First(e => e.Id == 2);

        delayedEquipment.IsAvailable = false;

        storage.Rentals.Add(new Rental(delayedUser, delayedEquipment, DateTime.Now.AddDays(-7), 3));

        int penalty2 = lendingService.ReturnEquipment(2);
        Console.WriteLine($"Returned, penalty: {penalty2}");

        Console.WriteLine();

        reportService.PrintSummary();
    }
}