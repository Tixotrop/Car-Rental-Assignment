using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System.Reflection;

namespace Car_Rental.Common.Classes;


// Car and mc extends vehicle
public class Car : Vehicle
{
    public Car(Vehicle vehicle) : base(vehicle) { }

    public Car(int id, string regNo, string make, double odometer, double costKM, VehicleTypes vehicleType, int costPerDay, VehicleStatuses status) 
        : base(id, regNo, make, odometer, costKM, vehicleType, costPerDay, status)
    {
    }
}
