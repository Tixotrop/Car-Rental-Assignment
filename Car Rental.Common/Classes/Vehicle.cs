using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Vehicle : IVehicle
{
    public int Id { get; }
    public string RegNo { get; set; } = string.Empty;

    public string Make { get; set; } = string.Empty;

    public double Odometer { get; set; }

    public double CostKM { get; set; }

    public VehicleTypes VehicleType { get; set; }

    public int CostPerDay { get; set; }

    public VehicleStatuses Status { get; set; }

    public Vehicle() { }

    public Vehicle(Vehicle vehicle)
    {
        foreach (PropertyInfo property in typeof(Vehicle).GetProperties().Where(p => p.CanWrite))
        {
            property.SetValue(this, property.GetValue(vehicle));
        }
    }

    public Vehicle(int id, string regNo, string make, double odometer, double costKM,
        VehicleTypes vehicleType, int costPerDay, VehicleStatuses status)
    {
        Id = id;
        RegNo = regNo;
        Make = make;
        Odometer = odometer;
        CostKM = costKM;
        VehicleType = vehicleType;
        CostPerDay = costPerDay;
        Status = status;
    }

}
