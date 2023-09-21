using Car_Rental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    public IVehicle Vehicle { get; set; }
    public IPerson Customer { get; set; }
    public int KmStart { get; set; }

    public int? KmReturn { get; set; }

    public DateTime Rented { get; set; }
    public DateTime? Returned { get; set; }

    public double? Cost { get; }

    public VehicleStatuses Status { get; set; } 


}
