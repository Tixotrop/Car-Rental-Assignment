using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Bookings : IBooking
{
    public IPerson Customer { get; set; }
    public IVehicle Vehicle { get; set; }
    public int KmStart { get; set; }
    public int? KmReturn { get; set; }
    public DateTime Rented { get; set; }
    public DateTime? Returned { get; set; }
    public VehicleStatuses Status { get; set; } = VehicleStatuses.Booked;
    public double? Cost { 
        get
        {
            if ((Returned is not null) && this.Status == VehicleStatuses.Available)
            {
                    return (((Returned?.Date - Rented.Date)?.Days + 1)*Vehicle.CostPerDay) + (KmReturn - KmStart) * Vehicle.CostKM; 

            }
            else
            {
                return null;
            }
        } 
    }


    public Bookings(IVehicle vehicle, IPerson customer, int kmStart, int? kmReturn, DateTime rented, 
        DateTime? returned, VehicleStatuses status)
    {
        Vehicle = vehicle;
        Customer = customer;
        KmStart = kmStart;
        KmReturn = kmReturn;
        Rented = rented;
        Returned = returned;
        Status = status;
    }

}
