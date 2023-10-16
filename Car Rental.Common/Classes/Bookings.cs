using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Bookings : IBooking
{
    public IPerson Customer { get; init; }
    public IVehicle Vehicle { get; init; }
    public int KmStart { get; init; }
    public int? KmReturn { get; private set; }
    public DateTime Rented { get; init; }
    public DateTime? Returned { get; private set; }
    public VehicleStatuses Status { get; private set; } = VehicleStatuses.Booked;
    public double? Cost { get; private set; }


    public Bookings(IVehicle vehicle, IPerson customer)
    {
        Vehicle = vehicle;
        Customer = customer;
        KmStart = vehicle.Odometer;
        Rented = DateTime.Now;
    }

    public void ReturnVehicle(IVehicle vehicle)
    {
        if (vehicle.RegNo != Vehicle.RegNo || Status.Equals(VehicleStatuses.Available)) return;
        KmReturn = vehicle.Odometer;    
        Vehicle.Status = VehicleStatuses.Available;
        Status = VehicleStatuses.Available;
        Returned = DateTime.Now;
        Cost = (((Returned?.Date - Rented.Date)?.Days + 1) * Vehicle.CostPerDay) + (KmReturn - KmStart) * Vehicle.CostKM;

    }

}
