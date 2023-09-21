using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData 
{
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IVehicle> _vehicles = new List<IVehicle>();
    readonly List<IBooking> _bookings = new List<IBooking>();

    public CollectionData() => SeedData();

    void SeedData()
    {
        Customer john = new Customer("1223", "John", "Doe");
        Customer jane = new Customer("1224", "Jane", "Doe");
        _persons.Add(john);
        _persons.Add(jane);

        Car tesla = new Car("GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100, VehicleStatuses.Booked);
        Car jeep = new Car("JKL012", "Jeep", 5000, 1.5, VehicleTypes.Sedan, 100, VehicleStatuses.Available);
        _vehicles.Add(new Car("ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200, VehicleStatuses.Available));
        _vehicles.Add(new Car("DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, 100, VehicleStatuses.Available));
        _vehicles.Add(tesla);
        _vehicles.Add(jeep);
        _vehicles.Add(new Motorcycle("MNO234", "Yamaha", 30000, 0.5, 50, VehicleStatuses.Available));


        IBooking booking1 = new Bookings(tesla, john, 1000, null, new DateTime(2023, 9, 9),
            null, VehicleStatuses.Booked);
        IBooking booking2 = new Bookings(jeep, jane, 5000, 5000, new DateTime(2023, 9, 9),
            new DateTime(2023, 9, 9), VehicleStatuses.Available);
        _bookings.Add(booking1);
        _bookings.Add(booking2);
    }

    public IEnumerable<IPerson> GetPersons() =>  _persons;
    public IEnumerable<IBooking> GetBooking() => _bookings;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;

}
