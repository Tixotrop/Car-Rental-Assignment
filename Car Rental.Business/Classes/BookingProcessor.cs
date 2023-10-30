using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;

    public BookingProcessor(IData db)
    {
        _db = db;
    }
    public IEnumerable<IBooking> GetBookings()
    {
        return _db.Get<IBooking>(null);
    }
    public IEnumerable<Customer> GetCustomers()
    {
        return _db.Get<IPerson>(null).Cast<Customer>().ToList();
    }

    public IPerson? GetPerson(string ssn)
    {
        return _db.Single<IPerson>(p => p.SSN == ssn);
    }

    public IEnumerable<Vehicle> GetVehicles(VehicleStatuses status = default)
    {
        if(status == default) return _db.Get<Vehicle>(null);
        return _db.Get<Vehicle>(v => v.Status == status);   
    }

    public Vehicle? GetVehicle(int vehicleId)
    {
        return _db.Single<Vehicle>(v => v.Id == vehicleId);
    }

    public Vehicle? GetVehicle(string regNo)
    {
        return _db.Single<Vehicle>(v => v.RegNo == regNo);
    }

    public async Task<bool> RentVehicle(int vehicleId, int customerId)
    {
        await Task.Delay(5000);
        _db.RentVehicle(vehicleId, customerId);
        return true;
    }

    public IBooking ReturnVehicle(int vehicleId, double distance)
    {
        return _db.ReturnVehicle(vehicleId, distance);

    }


    public void AddVehicle(Vehicle vehicle)
    {
        if (vehicle.VehicleType == VehicleTypes.Motorcycle)
        {
            Motorcycle mc = new Motorcycle(vehicle);
            mc.Status = VehicleStatuses.Available;
            _db.Add<Vehicle>(mc);
        }
        else
        {
            Car car = new Car(vehicle);
            car.Status = VehicleStatuses.Available;
            _db.Add<Vehicle>(car);
        }
    }

    public void AddCustomer(Customer customer)
    {
        _db.Add<IPerson>(customer);
    }

    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);
}
