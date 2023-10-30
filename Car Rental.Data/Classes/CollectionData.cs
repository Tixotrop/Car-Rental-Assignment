using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;
using System.Reflection;


namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{

    public CollectionData() => SeedData();

    void SeedData()
    {
        Customer john = new Customer(NextPersonId, "1223", "John", "Doe");
        _persons.Add(john);
        Customer jane = new Customer(NextPersonId, "1224", "Jane", "Doe");
        _persons.Add(jane);

        Car tesla = new Car(NextVehicleId, "GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100, VehicleStatuses.Booked);
        _vehicles.Add(tesla);
        Car jeep = new Car(NextVehicleId, "JKL012", "Jeep", 5000, 1.5, VehicleTypes.Sedan, 100, VehicleStatuses.Available);
        _vehicles.Add(jeep);
        _vehicles.Add(new Car(NextVehicleId, "ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200, VehicleStatuses.Available));
        _vehicles.Add(new Car(NextVehicleId, "DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, 100, VehicleStatuses.Available));
        _vehicles.Add(new Motorcycle(NextVehicleId, "MNO234", "Yamaha", 30000, 0.5, 50, VehicleStatuses.Available));

        IBooking booking1 = new Bookings(NextBookingId, tesla, john);
        _bookings.Add(booking1);
        IBooking booking2 = new Bookings(NextBookingId, jeep, jane);
        _bookings.Add(booking2);
        jeep.Odometer = 5200;
        booking2.ReturnVehicle();

    }

    private readonly List<IPerson> _persons = new List<IPerson>();
    private readonly List<Vehicle> _vehicles = new List<Vehicle>();
    private readonly List<IBooking> _bookings = new List<IBooking>();

    public int NextPersonId => _persons.Count == 0 ? 1 : _persons.Max(p => p.Id) + 1;
    public int NextVehicleId => _vehicles.Count == 0 ? 1 : _vehicles.Max(v => v.Id) + 1;

    public int NextBookingId => _bookings.Count == 0 ? 1 : _bookings.Max(b => b.Id) + 1;

    public void Add<T>(T item)
    {
        List<T> collection = GetList<T>();
        collection.Add(item);
    }

    private List<T> GetList<T>()
    {
        var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly)
                ?? throw new InvalidOperationException("Unsupported type");

        var value = collections.GetValue(this) ?? throw new InvalidDataException();

        return ((List<T>)value);
    }
    

    public T? Single<T>(Expression<Func<T, bool>>? expression)
    {
        if (expression == null) return default;
        return GetList<T>().AsQueryable().Single(expression);
    }

    public List<T> Get<T>(Expression<Func<T, bool>>? expression)
    {
        List<T> collection = GetList<T>();
        if (expression == null) return collection;
        return collection.AsQueryable().Where(expression).ToList();
    }

    public IBooking RentVehicle(int vehicleId, int customerId)
    {
        Vehicle vehicle = _vehicles.Single(v => v.Id == vehicleId);
        IPerson person = _persons.Single(p => p.Id == customerId);
        vehicle.Status = VehicleStatuses.Booked;
        var booking = new Bookings(NextBookingId, vehicle, person); 
        _bookings.Add(booking);
        return booking;
    }

    public IBooking ReturnVehicle(int vehicleId, double distance)
    {
        Vehicle vehicle = _vehicles.Single(v =>v.Id == vehicleId);
        vehicle.Odometer += distance;
        IBooking booking = _bookings.Single(b => b.Vehicle.Id == vehicleId);
        booking.ReturnVehicle();
        return booking;
    }
}
