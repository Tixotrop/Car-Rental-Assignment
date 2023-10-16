using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    public IVehicle Vehicle { get; init; }
    public IPerson Customer { get; init; }
    public int KmStart { get; init; }

    public int? KmReturn { get; }

    public DateTime Rented { get; init; }
    public DateTime? Returned { get;  }

    public double? Cost { get; }

    public VehicleStatuses Status { get;  }

    public void ReturnVehicle(IVehicle vehicle);
}
