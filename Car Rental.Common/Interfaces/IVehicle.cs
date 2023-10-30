using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{

    public int Id { get; }
    public string RegNo { get; }
    public string Make { get; }
    public double Odometer { get; set; }
    public double CostKM { get; set; }
    public VehicleTypes VehicleType { get; }
    public int CostPerDay { get; set; }
    public VehicleStatuses Status { get; set; }

}