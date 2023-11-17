namespace GarageLogic;

public class Garage 
{
    public ParkingSpot[] parkingSpots { get; } = new ParkingSpot[50];

    public bool IsOccupied(int parkingSpotNumber)
    {
        if (parkingSpots[parkingSpotNumber - 1] == null)
            return false;
        return true;
    }

    public bool TryOccupy(int parkingSpotNumber, string licensePlate, DateTime entryTime)
    {
        if (!IsOccupied(parkingSpotNumber))
        {
            parkingSpots[parkingSpotNumber - 1] = new ParkingSpot();
            parkingSpots[parkingSpotNumber - 1].licensePlate = licensePlate;
            parkingSpots[parkingSpotNumber - 1].entryDate = entryTime;
            return true;
        }
        return false;
    }

    public bool TryExit(int parkingSpotNumber, DateTime exitTime, out decimal costs)
    {
        if (IsOccupied(parkingSpotNumber))
        {
            TimeSpan parckedTime = exitTime - parkingSpots[parkingSpotNumber - 1].entryDate;

            if ((int)parckedTime.TotalMinutes <= 15)
                costs = 0;
            else
                costs = (((int)parckedTime.TotalMinutes / 30) + 1) * 3;

            parkingSpots[parkingSpotNumber - 1] = null!;

            return true;
        }

        costs = 0;
        return false;
    }

    public string GenerateReport()
    {
        string report = "| Spot | License Plate |\n| ---- | ------------- |\n";

        for (int i = 0; i < parkingSpots.Length; i++)
        {
            report += $"| {i + 1,-4} | {parkingSpots[i]?.licensePlate,-13} |\n";
        }

        return report;
    }
}