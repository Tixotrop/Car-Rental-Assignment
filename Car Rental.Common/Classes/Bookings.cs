using Car_Rental.Common.Enums;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Bookings : IBooking
{
    public int Id {get;}
    public IPerson Customer { get; init; }
    public Vehicle Vehicle { get; init; }
    public double KmStart { get; init; }
    public double? KmReturn { get; private set; }
    public DateTime Rented { get; init; }
    public DateTime? Returned { get; private set; }
    public VehicleStatuses Status { get; private set; } = VehicleStatuses.Booked;
    public double? Cost { get; private set; }


    public Bookings(int id, Vehicle vehicle, IPerson customer)
    {
        Id = id;
        Vehicle = vehicle;
        Customer = customer;
        KmStart = vehicle.Odometer;
        Rented = DateTime.Now;
    }

    public void ReturnVehicle()
    {
        if (Status.Equals(VehicleStatuses.Available)) return;
        KmReturn = Vehicle.Odometer;    
        Vehicle.Status = VehicleStatuses.Available;
        Status = VehicleStatuses.Available;
        Cost = (Rented.Duration(DateTime.Now) * Vehicle.CostPerDay) + (KmReturn - KmStart) * Vehicle.CostKM;

    }

}
