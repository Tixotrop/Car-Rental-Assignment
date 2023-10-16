using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Motorcycle : IVehicle
{
    public string RegNo { get; }

    public string Make { get;  }

    public int Odometer { get; set; }
    public double CostKM { get; set; }

    public VehicleTypes VehicleType => VehicleTypes.Motorcycle;

    public int CostPerDay { get; set; }
    public VehicleStatuses Status { get; set; }

    public Motorcycle(string regNo, string make, int odometer, double costKM, int costPerDay, VehicleStatuses status)
    {
        RegNo = regNo;
        Make = make;
        Odometer = odometer;
        CostKM = costKM;
        CostPerDay = costPerDay;
        Status = status;
    }
}
