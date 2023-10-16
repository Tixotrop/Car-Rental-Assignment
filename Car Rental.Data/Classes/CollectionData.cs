using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{

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

        IBooking booking1 = new Bookings(tesla, john);
        IBooking booking2 = new Bookings(jeep, jane);
        jeep.Odometer = 5200;
        booking2.ReturnVehicle(jeep);

        _bookings.Add(booking1);
        _bookings.Add(booking2);
    }

    public IEnumerable<IPerson> GetPersons() => _persons;
    public IEnumerable<IBooking> GetBooking() => _bookings;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles.Where(v => v.Status == status);

    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IVehicle> _vehicles = new List<IVehicle>();
    readonly List<IBooking> _bookings = new List<IBooking>();

    public void Add<T>(T item)
    {
        // Will be modified later: 
        switch (item)
        {
            case IPerson person:
                _persons.Add(person);
                break;
            case IVehicle vehicle:
                _vehicles.Add(vehicle);
                break;

            case IBooking booking:
                _bookings.Add(booking);
                break;
            default: break;
        }
    }


    public List<T> Get<T>(Expression<Func<T, bool>>? expression)
    {
        // Not developed yet.
        throw new NotImplementedException();
    }

    private List<T> Get<T>(List<T> list, Expression<Func<T, bool>>? expression)
    {
        // Not developed yet.
        throw new NotImplementedException();
    }


}
