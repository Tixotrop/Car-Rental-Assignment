using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    public int Id { get;}
    public Vehicle Vehicle { get; init; }
    public IPerson Customer { get; init; }
    public double KmStart { get; init; }

    public double? KmReturn { get; }

    public DateTime Rented { get; init; }
    public DateTime? Returned { get;  }

    public double? Cost { get; }

    public VehicleStatuses Status { get;  }

    public void ReturnVehicle();
}
