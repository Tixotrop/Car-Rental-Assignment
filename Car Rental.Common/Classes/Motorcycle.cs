using Car_Rental.Common.Enums;
using System.Reflection;

namespace Car_Rental.Common.Classes;

public class Motorcycle : Vehicle
{
    public Motorcycle(Vehicle vehicle) : base(vehicle) { }
   
    public Motorcycle(int id, string regNo, string make, double odometer, double costKM, int costPerDay, VehicleStatuses status) 
        : base(id, regNo, make, odometer, costKM, VehicleTypes.Motorcycle, costPerDay, status)
    {
    }
}
