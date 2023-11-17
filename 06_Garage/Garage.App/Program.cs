using GarageLogic;

internal class Program
{
    static Garage garage = new Garage();

    private static void Main(string[] args)
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1) Enter a car entry");
        Console.WriteLine("2) Enter a car exit");
        Console.WriteLine("3) Generate report");
        Console.WriteLine("4) Exit");
        System.Console.WriteLine();

        while (true)
        {
            Console.Write("Your selection: ");
            string selection = Console.ReadLine()!;
            System.Console.WriteLine();

            switch (selection)
            {
                case "1":
                    GenerateACarEntry();
                    break;
                case "2":
                    EnterACarExit();
                    break;
                case "3":
                    System.Console.WriteLine(garage.GenerateReport());
                    break;
                case "4":
                    System.Console.WriteLine("Good bye!");
                    Environment.Exit(0);
                    break;
            }

            System.Console.WriteLine();
        }
    }

    static void GenerateACarEntry()
    {
        System.Console.Write("Enter parking spot number: ");
        int parkingSpotNumber = Convert.ToInt32(Console.ReadLine());

        if (garage.IsOccupied(parkingSpotNumber))
            System.Console.WriteLine("Parking spot is occupied");
        else
        {
            System.Console.Write("Enter license plate: ");
            string licensePlate = Console.ReadLine()!;

            System.Console.Write("Enter entry date/time: ");
            DateTime entryTime = Convert.ToDateTime(Console.ReadLine());

            garage.TryOccupy(parkingSpotNumber, licensePlate, entryTime);
        }
    }

    static void EnterACarExit()
    {
        System.Console.Write("Enter parking spot number: ");
        int parkingSpotNumber = Convert.ToInt32(Console.ReadLine());

        if (!garage.IsOccupied(parkingSpotNumber))
            System.Console.WriteLine("Parking spot is not occupied");
        else
        {
            System.Console.Write("Enter exit date/time: ");
            DateTime exitTime = Convert.ToDateTime(Console.ReadLine());

            garage.TryExit(parkingSpotNumber, exitTime, out decimal costs);

            System.Console.WriteLine($"Costs are {costs}€");
        }
    }
}