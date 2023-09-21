using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Car : IVehicle
{
    
    public string RegNo { get; } = string.Empty;

    public string Make { get; } = string.Empty;

    public int Odometer { get; set; }

    public double CostKM { get; set; }

    public VehicleTypes VehicleType { get; }

    public int CostPerDay { get; set; }

    public VehicleStatuses Status { get; set; }

    public Car(string regNo, string make, int odometer, double costKM,
        VehicleTypes vehicleType, int costPerDay, VehicleStatuses status)
    {
        RegNo = regNo;
        Make = make;
        Odometer = odometer;
        CostKM = costKM;
        VehicleType = vehicleType;
        CostPerDay = costPerDay;
        Status = status;
    }

}
